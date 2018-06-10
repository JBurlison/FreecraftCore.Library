using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Vanilla 1.12.1 cast flags.
	/// </summary>
	[Flags]
	public enum SpellCastFlags_Vanilla : short
	{
		CAST_FLAG_NONE = 0x00000000,
		CAST_FLAG_HIDDEN_COMBATLOG = 0x00000001,               // hide in combat log?
		CAST_FLAG_UNKNOWN2 = 0x00000002,
		CAST_FLAG_UNKNOWN3 = 0x00000004,
		CAST_FLAG_UNKNOWN4 = 0x00000008,
		CAST_FLAG_UNKNOWN5 = 0x00000010,
		CAST_FLAG_AMMO = 0x00000020,               // Projectiles visual
		CAST_FLAG_UNKNOWN7 = 0x00000040,               // !0x41 mask used to call CGTradeSkillInfo::DoRecast
		CAST_FLAG_UNKNOWN8 = 0x00000080,
		CAST_FLAG_UNKNOWN9 = 0x00000100,
	};
}
