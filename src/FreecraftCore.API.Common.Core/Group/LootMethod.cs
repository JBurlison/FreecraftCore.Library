using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public enum LootMethod : byte
	{
		FREE_FOR_ALL = 0,
		ROUND_ROBIN = 1,
		MASTER_LOOT = 2,
		GROUP_LOOT = 3,
		NEED_BEFORE_GREED = 4
	}
}