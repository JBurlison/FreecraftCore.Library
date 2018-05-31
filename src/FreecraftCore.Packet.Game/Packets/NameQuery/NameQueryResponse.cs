using FreecraftCore.Serializer;

namespace FreecraftCore
{
	//TODO: Namequeries don't work for 1.12.1... not really for 3.3.5 either
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_NAME_QUERY_RESPONSE)]
	[ProtocolGrouping(ProtocolCode.Game)] //TODO: Change this protocol to something more specific
	public class NameQueryResponse : GamePacketPayload
	{
		/// <inheritdoc />
		public override bool isValid { get; } = true;

		//On 1.12.1 they don't send this object guid packed.
		/// <summary>
		/// The GUID requested in the name query request.
		/// </summary>
		[WireMember(1)]
		public PackedGuid RequestedGuid { get; private set; }

		/// <summary>
		/// The name query result.
		/// </summary>
		[WireMember(2)]
		public NameQueryResult Result { get; private set; }

		protected NameQueryResponse()
		{
			//serializer ctor
		}
	}
}
