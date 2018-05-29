using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using FreecraftCore;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Type marker for the game packet assembly.
	/// </summary>
	public static class GamePacketMetadataMarker
	{
		public static IReadOnlyCollection<Type> GamePacketPayloadTypes { get; }

		public static IReadOnlyCollection<Type> SerializableTypes { get; }

		public static IReadOnlyCollection<Type> AssemblyTypes { get; }

		public static Lazy<IReadOnlyCollection<Type>> GamePacketPayloadTypesWithDynamicProxies { get; }

		/// <summary>
		/// The backing field name for the dynamic proxy DTOs.
		/// </summary>
		public static string DynamicProxyDataBackingFieldName { get; } = "Data_backingfield";

		static GamePacketMetadataMarker()
		{
			AssemblyTypes = typeof(GamePacketMetadataMarker)
				.Assembly
				.GetExportedTypes();

			GamePacketPayloadTypes = AssemblyTypes
				.Where(t => typeof(GamePacketPayload).IsAssignableFrom(t))
				.ToArray();

			SerializableTypes = GamePacketPayloadTypes
				.Concat(AssemblyTypes.Where(t => t.GetCustomAttribute<WireDataContractAttribute>() != null))
				.Distinct()
				.ToArray();

			GamePacketPayloadTypesWithDynamicProxies = new Lazy<IReadOnlyCollection<Type>>(() => GamePacketPayloadTypes
				.Concat(GenerateDynamicProxyTemporaryDTOTypes(GamePacketPayloadTypes))
				.ToArray(), true);
		}

		public static IEnumerable<Type> GenerateDynamicProxyTemporaryDTOTypes(IEnumerable<Type> implementedPacketTypes)
		{
			NetworkOperationCode[] codes = implementedPacketTypes
				.Where(t => t.GetCustomAttribute<GamePayloadOperationCodeAttribute>(true) != null)
				.Select(t => t.GetCustomAttribute<GamePayloadOperationCodeAttribute>(true).OperationCode)
				.Distinct()
				.ToArray();

			ConstructorInfo opCodeAttributeCtor = typeof(GamePayloadOperationCodeAttribute).GetTypeInfo().DeclaredConstructors.First(c => c.GetParameters().Any(p => p.ParameterType == typeof(NetworkOperationCode)));
			ConstructorInfo wireDataContractAttributeCtor = typeof(WireDataContractAttribute).GetTypeInfo().DeclaredConstructors.First(c => c.GetParameters().Length == 3);
			ConstructorInfo readToEndAttributeCtor = typeof(ReadToEndAttribute).GetTypeInfo().DeclaredConstructors.First();
			ConstructorInfo wireMemberAttributeCtor = typeof(WireMemberAttribute).GetTypeInfo().DeclaredConstructors.First(c => c.GetParameters().Length > 0);

			ConcurrentBag<Type> types = new ConcurrentBag<Type>();

			Parallel.ForEach((((NetworkOperationCode[])Enum.GetValues(typeof(NetworkOperationCode)))
				.Where(o => !codes.Contains(o))), opcode =>
			{
				TypeBuilder tb = GetProxyDTOTypeBuilder($"{opcode.ToString()}_ProxyDTO");

				//KeyType keyType = KeyType.None, InformationHandlingFlags typeHandling = InformationHandlingFlags.Default, bool expectRuntimeLink = false
				object[] wireDataContractAttribute = new object[3] { WireDataContractAttribute.KeyType.None, InformationHandlingFlags.Default, false };
				object[] attributeArguments = new object[] { opcode };

				tb.SetCustomAttribute(new CustomAttributeBuilder(opCodeAttributeCtor, attributeArguments));
				tb.SetCustomAttribute(new CustomAttributeBuilder(wireDataContractAttributeCtor, wireDataContractAttribute));

				FieldBuilder fieldBuilder = tb.DefineField(DynamicProxyDataBackingFieldName, typeof(byte[]), FieldAttributes.Public);

				fieldBuilder.SetCustomAttribute(new CustomAttributeBuilder(readToEndAttributeCtor, new object[0]));
				fieldBuilder.SetCustomAttribute(new CustomAttributeBuilder(wireMemberAttributeCtor, new object[1] { 1 }));

				//Default ctor
				tb.DefineDefaultConstructor(MethodAttributes.Public);

				tb.AddInterfaceImplementation(typeof(IUnimplementedGamePacketPayload));
				BuildProperty(tb, nameof(IUnimplementedGamePacketPayload.Data), typeof(byte[]), fieldBuilder);

				//MethodBuilder getDataMethod = tb.DefineMethod("get_Data", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.Virtual, typeof(byte[]), new Type[0]);
				//MethodBuilder setDataMethod = tb.DefineMethod("set_Data", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.Virtual, typeof(byte[]), new Type[0]);

				/*
				TestClass.get_field:
				IL_0000:  ldarg.0     
				IL_0001:  ldfld       UserQuery+TestClass.backfield
				IL_0006:  ret         

				TestClass.set_field:
				IL_0000:  ldarg.0     
				IL_0001:  ldarg.1     
				IL_0002:  stfld       UserQuery+TestClass.backfield
				IL_0007:  ret   
				*/

				/*ILGenerator getIlGenerator = getDataMethod.GetILGenerator();
				getIlGenerator.Emit(OpCodes.Ldarg_0);
				getIlGenerator.Emit(OpCodes.Ldfld);
				getIlGenerator.Emit(OpCodes.Ret);

				ILGenerator setIlGenerator = setDataMethod.GetILGenerator();
				setIlGenerator.Emit(OpCodes.Ldarg_0);
				setIlGenerator.Emit(OpCodes.Ldarg_1);
				setIlGenerator.Emit(OpCodes.Stfld);
				setIlGenerator.Emit(OpCodes.Ret);*/


				types.Add(tb.CreateTypeInfo().AsType());
			});

			return types;
		}

		//From: https://stackoverflow.com/questions/5277291/implementing-interface-at-run-time-get-value-method-not-implemented?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
		private static void BuildProperty(TypeBuilder typeBuilder, string name, Type type, FieldBuilder backingField)
		{
			PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(name, PropertyAttributes.None, type, null);

			MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.HideBySig 
				| MethodAttributes.SpecialName | MethodAttributes.Virtual;

			MethodBuilder getter = typeBuilder.DefineMethod($"get_{name}", getSetAttr, type, Type.EmptyTypes);

			ILGenerator getIL = getter.GetILGenerator();
			getIL.Emit(OpCodes.Ldarg_0);
			getIL.Emit(OpCodes.Ldfld, backingField);
			getIL.Emit(OpCodes.Ret);

			MethodBuilder setter = typeBuilder.DefineMethod($"set_{name}", getSetAttr, null, new Type[] { type });

			ILGenerator setIL = setter.GetILGenerator();
			setIL.Emit(OpCodes.Ldarg_0);
			setIL.Emit(OpCodes.Ldarg_1);
			setIL.Emit(OpCodes.Stfld, backingField);
			setIL.Emit(OpCodes.Ret);


			propertyBuilder.SetGetMethod(getter);
			propertyBuilder.SetSetMethod(setter);
		}

		private static TypeBuilder GetProxyDTOTypeBuilder(string typeName)
		{
			var typeSignature = typeName;
			var an = new AssemblyName(typeSignature);
			AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("Game.ProxyDTOs");
			TypeBuilder tb = moduleBuilder.DefineType(typeSignature,
				TypeAttributes.Public |
				TypeAttributes.Class |
				TypeAttributes.AutoClass |
				TypeAttributes.AnsiClass |
				TypeAttributes.BeforeFieldInit |
				TypeAttributes.AutoLayout,
				typeof(GamePacketPayload));

			return tb;
		}

		[WireDataContract]
		internal class UnimplementedPacketDynamicInterceptor : IInterceptor, IUnimplementedGamePacketPayload
		{
			/// <inheritdoc />
			[ReadToEnd]
			[WireMember(1)]
			public byte[] Data { get; set; }

			/// <inheritdoc />
			public void Intercept(IInvocation invocation)
			{
				if(invocation.Method.Name == $"get_{nameof(IUnimplementedGamePacketPayload.Data)}")
				{
					invocation.ReturnValue = Data;
				}
				else if(invocation.Method.Name == $"set_{nameof(IUnimplementedGamePacketPayload.Data)}")
				{
					invocation.ReturnValue = Data;
					Data = invocation.GetArgumentValue(0) as byte[];
				}
				else if(invocation.Method.Name == nameof(GamePacketPayload.isValid))
				{
					invocation.ReturnValue = true;
				}
				else
					throw new InvalidOperationException($"Unable to proxy unimplemented packet Method: {invocation.Method}");
			}
		}
	}
}
