using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Known to be checked: 8, 0x40. Known: 4: Has death corpse. 0x80: CGUnit_C::CanCurrentFormMount. 0x10000: has wheels
	/// </summary>
	public enum CreatureModelDataFlags
	{
		/// <summary>
		/// Has death corpse
		/// </summary>
		SupportsDeathCorpse = 0x00000004,

		/// <summary>
		/// Will **not** show items in main/offhand.
		/// Cata.
		/// </summary>
		DontShowEquippedWeapons = 0x00000010,

		/// <summary>
		/// Can mount
		/// </summary>
		CanMount = 0x00000080,

		/// <summary>
		/// Has Wheels.
		/// </summary>
		HasWheels = 0x00010000
	}
}
