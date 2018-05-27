using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
		}
	}
}
