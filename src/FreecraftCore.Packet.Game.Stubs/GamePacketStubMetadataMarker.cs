using System;
using System.Collections.Generic;
using System.Linq;

namespace FreecraftCore
{
	/// <summary>
	/// Type marker for the game packet assembly.
	/// </summary>
	public static class GamePacketStubMetadataMarker
	{
		public static IReadOnlyCollection<Type> AssemblyTypes { get; }

		/// <summary>
		/// Gets the stub payload types.
		/// </summary>
		public static IReadOnlyCollection<Type> GamePacketPayloadStubTypes { get; }

		static GamePacketStubMetadataMarker()
		{
			AssemblyTypes = typeof(GamePacketStubMetadataMarker)
				.Assembly
				.GetExportedTypes();

			GamePacketPayloadStubTypes = AssemblyTypes
				.Where(t => typeof(GamePacketPayload).IsAssignableFrom(t))
				.ToArray();
		}
	}
}
