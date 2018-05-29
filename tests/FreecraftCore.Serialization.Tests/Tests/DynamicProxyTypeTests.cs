using System;
using System.Collections.Generic;
using System.Linq;
using FreecraftCore.Serializer;
using NUnit.Framework;
using Reflect.Extent;

namespace FreecraftCore
{
	[TestFixture]
	public sealed class DynamicProxyTypeTests
	{
		public static IReadOnlyCollection<Type> DynamicGeneratedTypes { get; } = GamePacketMetadataMarker.GenerateDynamicProxyTemporaryDTOTypes(new List<Type>())
			.ToArray();

		[Test]
		[TestCaseSource(nameof(DynamicGeneratedTypes))]
		public void Test_DynamicProxy_Temp_DTOs_Dont_Throw_On_Create(Type t)
		{
			Assert.DoesNotThrow(() => t.GetType());
		}

		[Test]
		[TestCaseSource(nameof(DynamicGeneratedTypes))]
		public void Test_DynamicProxy_All_Contain_Proper_Attributes(Type t)
		{
			//assert
			Assert.True(t.GetField(GamePacketMetadataMarker.DynamicProxyDataBackingFieldName).HasAttribute<ReadToEndAttribute>());
			Assert.True(t.GetField(GamePacketMetadataMarker.DynamicProxyDataBackingFieldName).HasAttribute<WireMemberAttribute>());
			Assert.True(t.HasAttribute<WireDataContractAttribute>());
			Assert.True(t.HasAttribute<GamePayloadOperationCodeAttribute>());
			Assert.True(typeof(IUnimplementedGamePacketPayload).IsAssignableFrom(t));
		}

		[Test]
		[TestCaseSource(nameof(DynamicGeneratedTypes))]
		public void Test_Can_Create_Unimplemented_Payload_Type(Type t)
		{
			//arrange
			GamePacketPayload obj = Activator.CreateInstance(t) as GamePacketPayload;

			//asset
			Assert.NotNull(obj);
			Assert.True(obj.isValid);
		}

		[Test]
		[TestCaseSource(nameof(DynamicGeneratedTypes))]
		public void Test_Can_Set_Data_On_Unimplemented_PayloadType(Type t)
		{
			//arrange
			byte[] bytes = Enumerable.Range(5, 100).Select(i => (byte)i).ToArray();
			IUnimplementedGamePacketPayload obj = Activator.CreateInstance(t) as IUnimplementedGamePacketPayload;

			//act
			Assert.DoesNotThrow(() => obj.Data = bytes);

			//assert
			Assert.NotNull(obj.Data);
			for(int i = 0; i < bytes.Length; i++)
				Assert.AreEqual(bytes[i], obj.Data[i]);
		}

		[Test]
		[TestCaseSource(nameof(DynamicGeneratedTypes))]
		public void Test_Can_Register_DynamicProxyDTOs_In_Serializer(Type t)
		{
			//arrange
			SerializerService serializer = new SerializerService();

			//act
			bool result = serializer.RegisterType(t);
			serializer.Compile();

			//assert
			Assert.True(result);
			Assert.True(serializer.isTypeRegistered(t));
		}

		[Test]
		[TestCaseSource(nameof(DynamicGeneratedTypes))]
		public void Test_Can_Serialize_DynamicProxyDTOs_(Type t)
		{
			//arrange
			SerializerService serializer = new SerializerService();
			serializer.RegisterType(t);
			byte[] bytes = Enumerable.Range(5, 100).Select(i => (byte)i).ToArray();
			IUnimplementedGamePacketPayload obj = Activator.CreateInstance(t) as IUnimplementedGamePacketPayload;
			obj.Data = bytes;
			serializer.Compile();

			//act
			byte[] serializedBytes = serializer.Serialize(obj as GamePacketPayload);

			//assert
			Assert.NotNull(serializedBytes);
			Assert.AreEqual(bytes.Length + sizeof(NetworkOperationCode), serializedBytes.Length);

			for(int i = 0; i < bytes.Length; i++)
				Assert.AreEqual(bytes[i], serializedBytes[i + 2]);
		}
	}
}
