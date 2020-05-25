using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public enum MeleeHitOutcome : byte
	{
		MELEE_HIT_EVADE, 
		MELEE_HIT_MISS, 
		MELEE_HIT_DODGE, 
		MELEE_HIT_BLOCK, 
		MELEE_HIT_PARRY,
		MELEE_HIT_GLANCING, 
		MELEE_HIT_CRIT, 
		MELEE_HIT_CRUSHING, 
		MELEE_HIT_NORMAL
	};
}
