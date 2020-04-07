using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public enum AchievementCriteriaTimedTypes
	{
		/// <summary>
		/// Timer is started by internal event with id in timerStartEvent
		/// </summary>
		ACHIEVEMENT_TIMED_TYPE_EVENT = 1, 

		/// <summary>
		/// Timer is started by accepting quest with entry in timerStartEvent
		/// </summary>
		ACHIEVEMENT_TIMED_TYPE_QUEST = 2,

		/// <summary>
		/// Timer is started by casting a spell with entry in timerStartEvent
		/// </summary>
		ACHIEVEMENT_TIMED_TYPE_SPELL_CASTER = 5,

		/// <summary>
		/// Timer is started by being target of spell with entry in timerStartEvent
		/// </summary>
		ACHIEVEMENT_TIMED_TYPE_SPELL_TARGET = 6,

		/// <summary>
		/// Timer is started by killing creature with entry in timerStartEvent
		/// </summary>
		ACHIEVEMENT_TIMED_TYPE_CREATURE = 7,

		/// <summary>
		/// Timer is started by using item with entry in timerStartEvent
		/// </summary>
		ACHIEVEMENT_TIMED_TYPE_ITEM = 9
	};
}
