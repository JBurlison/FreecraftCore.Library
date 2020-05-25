using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public enum MeleeHitOutcome : byte
	{
		EVADE,
		MISS,
		DODGE,
		BLOCK,
		PARRY,
		GLANCING,
		CRIT,
		CRUSHING,
		NORMAL
	};
}
