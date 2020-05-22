using System;

namespace FreecraftCore
{
	/// <summary>
	/// Enumeration of all spell mechanics
	/// </summary>
	public enum SpellMechanic
	{
		NONE = 0,
		CHARM = 1,
		DISORIENTED = 2,
		DISARM = 3,
		DISTRACT = 4,
		FEAR = 5,
		GRIP = 6,
		ROOT = 7,
		SLOW_ATTACK = 8,
		SILENCE = 9,
		SLEEP = 10,
		SNARE = 11,
		STUN = 12,
		FREEZE = 13,
		KNOCKOUT = 14,
		BLEED = 15,
		BANDAGE = 16,
		POLYMORPH = 17,
		BANISH = 18,
		SHIELD = 19,
		SHACKLE = 20,
		MOUNT = 21,
		INFECTED = 22,
		TURN = 23,
		HORROR = 24,
		INVULNERABILITY = 25,
		INTERRUPT = 26,
		DAZE = 27,
		DISCOVERY = 28,
		IMMUNE_SHIELD = 29,  // Divine (Blessing) Shield/Protection and Ice Block
		SAPPED = 30,
		ENRAGED = 31
	};

	/// <summary>
	/// Enumeration of all spell mechanics
	/// </summary>
	[Flags]
	public enum SpellMechanicMask
	{
		CHARM = 1 << SpellMechanic.CHARM - 1,
		DISORIENTED = 1 << SpellMechanic.DISORIENTED - 1,
		DISARM = 1 << SpellMechanic.DISARM - 1,
		DISTRACT = 1 << SpellMechanic.DISTRACT - 1,
		FEAR = 1 << SpellMechanic.FEAR - 1,
		GRIP = 1 << SpellMechanic.GRIP - 1,
		ROOT = 1 << SpellMechanic.ROOT - 1,
		SLOW_ATTACK = 1 << SpellMechanic.SLOW_ATTACK - 1,
		SILENCE = 1 << SpellMechanic.SILENCE - 1,
		SLEEP = 1 << SpellMechanic.SLEEP - 1,
		SNARE = 1 << SpellMechanic.SNARE - 1,
		STUN = 1 << SpellMechanic.STUN - 1,
		FREEZE = 1 << SpellMechanic.FREEZE - 1,
		KNOCKOUT = 1 << SpellMechanic.KNOCKOUT - 1,
		BLEED = 1 << SpellMechanic.BLEED - 1,
		BANDAGE = 1 << SpellMechanic.BANDAGE - 1,
		POLYMORPH = 1 << SpellMechanic.POLYMORPH - 1,
		BANISH = 1 << SpellMechanic.BANISH - 1,
		SHIELD = 1 << SpellMechanic.SHIELD - 1,
		SHACKLE = 1 << SpellMechanic.SHACKLE - 1,
		MOUNT = 1 << SpellMechanic.MOUNT - 1,
		INFECTED = 1 << SpellMechanic.INFECTED - 1,
		TURN = 1 << SpellMechanic.TURN - 1,
		HORROR = 1 << SpellMechanic.HORROR - 1,
		INVULNERABILITY = 1 << SpellMechanic.INVULNERABILITY - 1,
		INTERRUPT = 1 << SpellMechanic.INTERRUPT - 1,
		DAZE = 1 << SpellMechanic.DAZE - 1,
		DISCOVERY = 1 << SpellMechanic.DISCOVERY - 1,
		IMMUNE_SHIELD = 1 << SpellMechanic.IMMUNE_SHIELD - 1,  // Divine (Blessing) Shield/Protection and Ice Block
		SAPPED = 1 << SpellMechanic.SAPPED - 1,
		ENRAGED = 1 << SpellMechanic.ENRAGED - 1,
	};
}