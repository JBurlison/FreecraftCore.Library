using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.CMSG_BEGIN_TRADE)]
	public sealed class ClientBeginTradePayload : GamePacketPayload
	{
		/// <summary>
		/// This packet is just empty?? TC handles no data from it.
		/// </summary>
		public ClientBeginTradePayload()
		{

		}
	}
}
