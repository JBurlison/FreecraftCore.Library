using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Response to a <see cref="NetworkOperationCode.CMSG_PING"/>.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_PONG)]
	public sealed class PongResponse : GamePacketPayload
	{
		/// <inheritdoc />
		public override bool isValid => true;

		[WireMember(1)]
		public uint Ping { get; private set; }

		public PongResponse(uint ping)
		{
			Ping = ping;
		}

		private PongResponse()
		{
			
		}
	}
}
