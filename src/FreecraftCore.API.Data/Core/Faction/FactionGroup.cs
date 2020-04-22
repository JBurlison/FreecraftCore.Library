using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Based on FactionMasks
	/// </summary>
	public enum FactionGroup
	{
		/// <summary>
		/// Player
		/// </summary>
		PLAYER = 1,

		/// <summary>
		/// Player or creature from alliance team
		/// </summary>
		ALLIANCE = 2,

		/// <summary>
		/// Player or creature from horde team
		/// </summary>
		HORDE = 3,

		/// <summary>
		/// Aggressive creature from monster team
		/// </summary>
		MONSTER = 4
	}

	/// <summary>
	/// based 
	/// </summary>
	[Flags]
	public enum FactionGroupMask
	{
		PLAYER = 1 << FactionGroup.PLAYER - 1,
		ALLIANCE = 1 << FactionGroup.ALLIANCE - 1,
		HORDE = 1 << FactionGroup.HORDE - 1,
		MONSTER = 1 << FactionGroup.MONSTER - 1,
	};
}
