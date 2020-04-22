using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	[Flags]
	public enum FactionTemplateFlags
	{
		/// <summary>
		/// Flagged for PvP
		/// </summary>
		FLAG_PVP = 0x00000800,

		/// <summary>
		/// Faction will attack players that were involved in PvP combats
		/// </summary>
		FLAG_CONTESTED_GUARD = 0x00001000,

		FLAG_HOSTILE_BY_DEFAULT = 0x00002000
	};
}
