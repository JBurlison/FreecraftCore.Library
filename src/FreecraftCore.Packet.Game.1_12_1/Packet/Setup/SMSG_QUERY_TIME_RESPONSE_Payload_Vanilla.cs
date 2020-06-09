using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Server response to <see cref="NetworkOperationCode.CMSG_QUERY_TIME"/>
	/// for 1.12.1.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_QUERY_TIME_RESPONSE)]
	public class SMSG_QUERY_TIME_RESPONSE_Payload_Vanilla : GamePacketPayload
	{
		/// <summary>
		/// The current time.
		/// </summary>
		[WireMember(1)]
		public uint CurrentTime { get; internal set; }

		//1.12.1 only sends current time. Has no daily

		/// <inheritdoc />
		public SMSG_QUERY_TIME_RESPONSE_Payload_Vanilla(uint currentTime)
		{
			CurrentTime = currentTime;
		}

		/// <summary>
		/// Creates a default time response payload
		/// with the current time.
		/// </summary>
		public SMSG_QUERY_TIME_RESPONSE_Payload_Vanilla()
		{

		}
	}
}
