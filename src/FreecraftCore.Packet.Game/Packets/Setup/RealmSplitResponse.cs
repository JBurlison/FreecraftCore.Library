using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Sent to the connecting during character list
	/// in response to <see cref="NetworkOperationCode.CMSG_REALM_SPLIT"/>.
	/// Sent with <see cref="NetworkOperationCode.SMSG_REALM_SPLIT"/>.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_REALM_SPLIT)]
	public sealed class RealmSplitResponse : GamePacketPayload
	{
		/// <inheritdoc />
		public override bool isValid => true;

		[ReadToEnd]
		[WireMember(1)]
		public byte[] Data { get; }

		public RealmSplitResponse()
		{
			
		}
	}
}
