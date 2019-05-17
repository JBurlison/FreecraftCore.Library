using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_TRADE_STATUS)]
	public sealed class ServerTradeStatusPayload : GamePacketPayload
	{
		[WireMember(1)]
		public TradeStatus Status { get; }

		/// <inheritdoc />
		public ServerTradeStatusPayload(TradeStatus status)
		{
			if(!Enum.IsDefined(typeof(TradeStatus), status)) throw new InvalidEnumArgumentException(nameof(status), (int)status, typeof(TradeStatus));

			Status = status;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		private ServerTradeStatusPayload()
		{

		}
	}
}
