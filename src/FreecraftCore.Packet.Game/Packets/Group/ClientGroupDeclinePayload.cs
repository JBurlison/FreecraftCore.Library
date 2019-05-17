using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.CMSG_GROUP_DECLINE)]
	public sealed class ClientGroupDeclinePayload : GamePacketPayload
	{
		/// <summary>
		/// This just sends an empty group decline packet.
		/// </summary>
		public ClientGroupDeclinePayload()
		{

		}
	}
}
