using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// 1.12.1 implementation of <see cref="NetworkOperationCode.SMSG_NAME_QUERY_RESPONSE"/>.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_NAME_QUERY_RESPONSE)]
	[ProtocolGrouping(ProtocolCode.Game)] //TODO: Change this protocol to something more specific
	public class SMSG_NAME_QUERY_RESPONSE_Payload_Vanilla : GamePacketPayload
	{
		//On 1.12.1 they don't send this object guid packed.
		/// <summary>
		/// The GUID requested in the name query request.
		/// </summary>
		[WireMember(1)]
		public ObjectGuid RequestedGuid { get; internal set; }
		
		//1.12.1 always sends, no response code

		/// <summary>
		/// The name query result.
		/// </summary>
		[WireMember(2)]
		public NameQueryResult Result { get; internal set; }

		/// <inheritdoc />
		public SMSG_NAME_QUERY_RESPONSE_Payload_Vanilla([NotNull] ObjectGuid requestedGuid, [NotNull] NameQueryResult result)
		{
			RequestedGuid = requestedGuid ?? throw new ArgumentNullException(nameof(requestedGuid));
			Result = result ?? throw new ArgumentNullException(nameof(result));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected SMSG_NAME_QUERY_RESPONSE_Payload_Vanilla()
		{

		}
	}
}
