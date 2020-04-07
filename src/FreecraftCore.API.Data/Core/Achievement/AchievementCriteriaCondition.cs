using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public enum AchievementCriteriaCondition
	{
		NONE = 0,

		/// <summary>
		/// reset progress on death
		/// </summary>
		NO_DEATH = 1,

		/// <summary>
		/// only used in "Complete a daily quest every day for five consecutive days"
		/// </summary>
		UNK2 = 2,    // 

		/// <summary>
		/// requires you to be on specific map, reset at change
		/// </summary>
		BG_MAP = 3,    //

		/// <summary>
		/// only used in "Win 10 arenas without losing"
		/// </summary>
		NO_LOSE = 4,    //

		/// <summary>
		/// requires the player not to be hit by specific spell
		/// </summary>
		NO_SPELL_HIT = 9,

		/// <summary>
		/// requires the player not to be in group
		/// </summary>
		NOT_IN_GROUP = 10,

		UNK13 = 13,
	}
}
