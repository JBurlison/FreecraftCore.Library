using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	//Based on TC's: enum SpellMissInfo
	/// <summary>
	/// Enumeration of spell miss reasons.
	/// </summary>
	public enum SpellMissReasonType : byte
	{
		SPELL_MISS_NONE = 0,
		SPELL_MISS_MISS = 1,
		SPELL_MISS_RESIST = 2,
		SPELL_MISS_DODGE = 3,
		SPELL_MISS_PARRY = 4,
		SPELL_MISS_BLOCK = 5,
		SPELL_MISS_EVADE = 6,
		SPELL_MISS_IMMUNE = 7,
		SPELL_MISS_IMMUNE2 = 8, // one of these 2 is MISS_TEMPIMMUNE
		SPELL_MISS_DEFLECT = 9,
		SPELL_MISS_ABSORB = 10,
		SPELL_MISS_REFLECT = 11
	};
}
