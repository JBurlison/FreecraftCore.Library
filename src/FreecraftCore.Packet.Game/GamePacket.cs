using System;
using JetBrains.Annotations;

namespace FreecraftCore
{
	//I tried to make this compatible with the serializer
	//There was too much bitpacking/shifting based on incoming
	//bits, which determine the true type information, and
	//so it has to be done by hand for now.
	/// <summary>
	/// A game packet.
	/// </summary>
	public class GamePacket : INetworkPacket<NetworkOperationCode, IGamePacketHeader, GamePacketPayload>
	{
		/// <summary>
		/// Header data associated with the packet.
		/// </summary>
		[NotNull]
		public IGamePacketHeader Header { get; }

		/// <inheritdoc />
		[NotNull]
		public GamePacketPayload Payload { get; }

		public GamePacket([NotNull] IGamePacketHeader header, [NotNull] GamePacketPayload payload)
		{
			if (header == null)
				throw new ArgumentNullException(nameof(header), $"Must provided a non-null header.");

			if (payload == null)
				throw new ArgumentNullException(nameof(payload), $"Must provided a non-null {nameof(IGamePacketPayload)}.");

			Payload = payload;
			Header = header;
		}
	}
}
