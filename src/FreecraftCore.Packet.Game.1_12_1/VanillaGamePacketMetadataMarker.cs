using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Type marker for the game packet assembly.
	/// </summary>
	public static class VanillaGamePacketMetadataMarker
	{
		public static IReadOnlyCollection<Type> VanillaGamePacketPayloadTypes { get; }

		public static IReadOnlyCollection<Type> SerializableTypes { get; }

		public static IReadOnlyCollection<Type> AssemblyTypes { get; }

		public static Lazy<IReadOnlyCollection<NetworkOperationCode>> UnimplementedOperationCodes { get; }

		static VanillaGamePacketMetadataMarker()
		{
			AssemblyTypes = typeof(VanillaGamePacketMetadataMarker)
				.Assembly
				.GetExportedTypes();

			VanillaGamePacketPayloadTypes = AssemblyTypes
				.Where(t => typeof(GamePacketPayload).IsAssignableFrom(t))
				.ToArray();

			SerializableTypes = VanillaGamePacketPayloadTypes
				.Concat(AssemblyTypes.Where(t => t.GetCustomAttribute<WireDataContractAttribute>() != null))
				.Distinct()
				.ToArray();

			UnimplementedOperationCodes = new Lazy<IReadOnlyCollection<NetworkOperationCode>>(() =>
			{
				var codes = VanillaGamePacketPayloadTypes
					.Where(t => t.GetCustomAttribute<GamePayloadOperationCodeAttribute>(true) != null)
					.Select(t => t.GetCustomAttribute<GamePayloadOperationCodeAttribute>(true).OperationCode)
					.Distinct()
					.ToArray();

				return ((NetworkOperationCode[])Enum.GetValues(typeof(NetworkOperationCode)))
					.Where(o => !codes.Contains(o))
					.ToArray();
			}, true);
		}
	}
}
