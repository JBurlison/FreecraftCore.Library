using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	//TODO: Add comments as field docs.
	/// <summary>
	/// Value masks for UNIT_FIELD_FLAGS
	/// </summary>
	[Flags]
	public enum UnitFlags : uint
	{
		UNIT_FLAG_SERVER_CONTROLLED = 0x00000001,           // set only when unit movement is controlled by server - by SPLINE/MONSTER_MOVE packets, together with UNIT_FLAG_STUNNED; only set to units controlled by client; client function CGUnit_C::IsClientControlled returns false when set for owner
		UNIT_FLAG_NON_ATTACKABLE = 0x00000002,           // not attackable
		UNIT_FLAG_REMOVE_CLIENT_CONTROL = 0x00000004,           // This is a legacy flag used to disable movement player's movement while controlling other units, SMSG_CLIENT_CONTROL replaces this functionality clientside now. CONFUSED and FLEEING flags have the same effect on client movement asDISABLE_MOVE_CONTROL in addition to preventing spell casts/autoattack (they all allow climbing steeper hills and emotes while moving)
		UNIT_FLAG_PLAYER_CONTROLLED = 0x00000008,           // controlled by player, use _IMMUNE_TO_PC instead of _IMMUNE_TO_NPC
		UNIT_FLAG_RENAME = 0x00000010,
		UNIT_FLAG_PREPARATION = 0x00000020,           // don't take reagents for spells with SPELL_ATTR5_NO_REAGENT_WHILE_PREP
		UNIT_FLAG_UNK_6 = 0x00000040,
		UNIT_FLAG_NOT_ATTACKABLE_1 = 0x00000080,           // ?? (UNIT_FLAG_PLAYER_CONTROLLED | UNIT_FLAG_NOT_ATTACKABLE_1) is NON_PVP_ATTACKABLE
		UNIT_FLAG_IMMUNE_TO_PC = 0x00000100,           // disables combat/assistance with PlayerCharacters (PC) - see Unit::IsValidAttackTarget, Unit::IsValidAssistTarget
		UNIT_FLAG_IMMUNE_TO_NPC = 0x00000200,           // disables combat/assistance with NonPlayerCharacters (NPC) - see Unit::IsValidAttackTarget, Unit::IsValidAssistTarget
		UNIT_FLAG_LOOTING = 0x00000400,           // loot animation
		UNIT_FLAG_PET_IN_COMBAT = 0x00000800,           // on player pets: whether the pet is chasing a target to attack || on other units: whether any of the unit's minions is in combat
		UNIT_FLAG_PVP = 0x00001000,           // changed in 3.0.3
		UNIT_FLAG_SILENCED = 0x00002000,           // silenced, 2.1.1
		UNIT_FLAG_CANNOT_SWIM = 0x00004000,           // 2.0.8
		UNIT_FLAG_SWIMMING = 0x00008000,           // shows swim animation in water
		UNIT_FLAG_NON_ATTACKABLE_2 = 0x00010000,           // removes attackable icon, if on yourself, cannot assist self but can cast TARGET_SELF spells - added by SPELL_AURA_MOD_UNATTACKABLE
		UNIT_FLAG_PACIFIED = 0x00020000,           // 3.0.3 ok
		UNIT_FLAG_STUNNED = 0x00040000,           // 3.0.3 ok
		UNIT_FLAG_IN_COMBAT = 0x00080000,
		UNIT_FLAG_TAXI_FLIGHT = 0x00100000,           // disable casting at client side spell not allowed by taxi flight (mounted?), probably used with 0x4 flag
		UNIT_FLAG_DISARMED = 0x00200000,           // 3.0.3, disable melee spells casting..., "Required melee weapon" added to melee spells tooltip.
		UNIT_FLAG_CONFUSED = 0x00400000,
		UNIT_FLAG_FLEEING = 0x00800000,
		UNIT_FLAG_POSSESSED = 0x01000000,           // under direct client control by a player (possess or vehicle)
		UNIT_FLAG_NOT_SELECTABLE = 0x02000000,
		UNIT_FLAG_SKINNABLE = 0x04000000,
		UNIT_FLAG_MOUNT = 0x08000000,
		UNIT_FLAG_UNK_28 = 0x10000000,
		UNIT_FLAG_UNK_29 = 0x20000000,           // used in Feing Death spell
		UNIT_FLAG_SHEATHE = 0x40000000,
		UNIT_FLAG_IMMUNE = 0x80000000,           // Immune to damage
	};

	/// <summary>
	/// Value masks for UNIT_FIELD_FLAGS_2
	/// </summary>
	[Flags]
	public enum UnitFlags2 : uint
	{
		UNIT_FLAG2_FEIGN_DEATH = 0x00000001,
		UNIT_FLAG2_UNK1 = 0x00000002,   // Hide unit model (show only player equip)
		UNIT_FLAG2_IGNORE_REPUTATION = 0x00000004,
		UNIT_FLAG2_COMPREHEND_LANG = 0x00000008,
		UNIT_FLAG2_MIRROR_IMAGE = 0x00000010,
		UNIT_FLAG2_INSTANTLY_APPEAR_MODEL = 0x00000020,   // Unit model instantly appears when summoned (does not fade in)
		UNIT_FLAG2_FORCE_MOVEMENT = 0x00000040,
		UNIT_FLAG2_DISARM_OFFHAND = 0x00000080,
		UNIT_FLAG2_DISABLE_PRED_STATS = 0x00000100,   // Player has disabled predicted stats (Used by raid frames)
		UNIT_FLAG2_DISARM_RANGED = 0x00000400,   // this does not disable ranged weapon display (maybe additional flag needed?)
		UNIT_FLAG2_REGENERATE_POWER = 0x00000800,
		UNIT_FLAG2_RESTRICT_PARTY_INTERACTION = 0x00001000,   // Restrict interaction to party or raid
		UNIT_FLAG2_PREVENT_SPELL_CLICK = 0x00002000,   // Prevent spellclick
		UNIT_FLAG2_ALLOW_ENEMY_INTERACT = 0x00004000,
		UNIT_FLAG2_DISABLE_TURN = 0x00008000,
		UNIT_FLAG2_UNK2 = 0x00010000,
		UNIT_FLAG2_PLAY_DEATH_ANIM = 0x00020000,   // Plays special death animation upon death
		UNIT_FLAG2_ALLOW_CHEAT_SPELLS = 0x00040000    // Allows casting spells with AttributesEx7 & SPELL_ATTR7_IS_CHEAT_SPELL
	};
}
