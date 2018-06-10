using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public enum ItemBondingType : int
	{
		NO_BIND = 0,
		BIND_WHEN_PICKED_UP = 1,
		BIND_WHEN_EQUIPED = 2,
		BIND_WHEN_USE = 3,
		BIND_QUEST_ITEM = 4,
		BIND_QUEST_ITEM1 = 5         // not used in game
	}
}
