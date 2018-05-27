using System;
using System.Collections.Generic;
using System.Linq;
using FreecraftCore.API.Common.Warden;
using FreecraftCore.Packet.Common;
using FreecraftCore.Serializer;

namespace FreecraftCore.Packet
{
	/// <summary>
	/// Base contract for all Warden payloads sent by the server.
	/// Sent with <see cref="NetworkOperationCode.SMSG_WARDEN_DATA"/>.
	/// </summary>
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_WARDEN_DATA)]
	public class WardenDataEvent : GamePacketPayload
	{
		[ReadToEnd]
		[WireMember(1)]
		public byte[] Data { get; }

		/// <inheritdoc />
		public override bool isValid => true;

		protected WardenDataEvent()
		{
			
		}
	}
}
