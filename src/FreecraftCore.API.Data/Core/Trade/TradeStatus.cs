using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public enum TradeStatus : int
	{
		TRADE_STATUS_BUSY = 0,
		TRADE_STATUS_BEGIN_TRADE = 1,
		TRADE_STATUS_OPEN_WINDOW = 2,
		TRADE_STATUS_TRADE_CANCELED = 3,
		TRADE_STATUS_TRADE_ACCEPT = 4,
		TRADE_STATUS_BUSY_2 = 5,
		TRADE_STATUS_NO_TARGET = 6,
		TRADE_STATUS_BACK_TO_TRADE = 7,
		TRADE_STATUS_TRADE_COMPLETE = 8,
		TRADE_STATUS_TRADE_REJECTED = 9,
		TRADE_STATUS_TARGET_TO_FAR = 10,
		TRADE_STATUS_WRONG_FACTION = 11,
		TRADE_STATUS_CLOSE_WINDOW = 12,
		// 13?
		TRADE_STATUS_IGNORE_YOU = 14,
		TRADE_STATUS_YOU_STUNNED = 15,
		TRADE_STATUS_TARGET_STUNNED = 16,
		TRADE_STATUS_YOU_DEAD = 17,
		TRADE_STATUS_TARGET_DEAD = 18,
		TRADE_STATUS_YOU_LOGOUT = 19,
		TRADE_STATUS_TARGET_LOGOUT = 20,
		TRADE_STATUS_TRIAL_ACCOUNT = 21,                       // Trial accounts can not perform that action
		TRADE_STATUS_WRONG_REALM = 22,                       // You can only trade conjured items... (cross realm BG related).
		TRADE_STATUS_NOT_ON_TAPLIST = 23                        // Related to trading soulbound loot items
	}
}
