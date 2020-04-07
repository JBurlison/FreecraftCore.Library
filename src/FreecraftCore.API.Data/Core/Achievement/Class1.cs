using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	enum AchievementCriteriaCondition
	{
		ACHIEVEMENT_CRITERIA_CONDITION_NONE = 0,
		ACHIEVEMENT_CRITERIA_CONDITION_NO_DEATH = 1,    // reset progress on death
		ACHIEVEMENT_CRITERIA_CONDITION_UNK2 = 2,    // only used in "Complete a daily quest every day for five consecutive days"
		ACHIEVEMENT_CRITERIA_CONDITION_BG_MAP = 3,    // requires you to be on specific map, reset at change
		ACHIEVEMENT_CRITERIA_CONDITION_NO_LOSE = 4,    // only used in "Win 10 arenas without losing"
		ACHIEVEMENT_CRITERIA_CONDITION_NO_SPELL_HIT = 9,    // requires the player not to be hit by specific spell
		ACHIEVEMENT_CRITERIA_CONDITION_NOT_IN_GROUP = 10,   // requires the player not to be in group
		ACHIEVEMENT_CRITERIA_CONDITION_UNK13 = 13,   // unk

		ACHIEVEMENT_CRITERIA_CONDITION_MAX
	};
}
