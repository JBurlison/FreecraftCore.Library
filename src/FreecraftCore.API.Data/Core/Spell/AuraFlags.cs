using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Based on TrinityCore enum AURA_FLAGS.
	/// </summary>
	public enum AuraFlags : byte
	{
		NONE = 0x00,

		EFF_INDEX_0 = 0x01,

		EFF_INDEX_1 = 0x02,

		EFF_INDEX_2 = 0x04,

		CASTER = 0x08,

		POSITIVE = 0x10,

		DURATION = 0x20,

		/// <summary>
		/// Used with AFLAG_EFF_INDEX_0/1/2
		/// </summary>
		ANY_EFFECT_AMOUNT_SENT = 0x40,

		NEGATIVE = 0x80
	}
}
