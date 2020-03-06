using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	[Flags]
	public enum GroupMemberOnlineStatus : byte
	{
		MEMBER_STATUS_OFFLINE = 0x0000,
		MEMBER_STATUS_ONLINE = 0x0001,                       // Lua_UnitIsConnected
		MEMBER_STATUS_PVP = 0x0002,                       // Lua_UnitIsPVP
		MEMBER_STATUS_DEAD = 0x0004,                       // Lua_UnitIsDead
		MEMBER_STATUS_GHOST = 0x0008,                       // Lua_UnitIsGhost
		MEMBER_STATUS_PVP_FFA = 0x0010,                       // Lua_UnitIsPVPFreeForAll
		MEMBER_STATUS_UNK3 = 0x0020,                       // used in calls from Lua_GetPlayerMapPosition/Lua_GetBattlefieldFlagPosition
		MEMBER_STATUS_AFK = 0x0040,                       // Lua_UnitIsAFK
		MEMBER_STATUS_DND = 0x0080                        // Lua_UnitIsDND
	}
}
