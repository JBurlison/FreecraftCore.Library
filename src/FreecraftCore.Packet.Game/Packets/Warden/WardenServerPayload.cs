using System;
using System.Collections.Generic;
using System.Linq;
using FreecraftCore;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Base contract for all Warden payloads sent by the server.
	/// Sent with <see cref="NetworkOperationCode.SMSG_WARDEN_DATA"/>.
	/// </summary>
	/*[GamePayloadOperationCode(NetworkOperationCode.SMSG_WARDEN_DATA)]
	[WireDataContract(WireDataContractAttribute.KeyType.Byte, InformationHandlingFlags.DontConsumeRead)] //don't consume type information
	public abstract class WardenServerPayload : GamePacketPayload
	{
		[DontWrite] //don't write; it's from type information
		[WireMember(1)]
		public WardenSubOperationCodeServer SubOperationCode { get; private set; }

		[ReadToEnd]
		[WireMember(2)]
		public byte[] Data { get; }

		protected WardenServerPayload()
		{
			
		}
	}*/
}
