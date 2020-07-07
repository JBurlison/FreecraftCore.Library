namespace FreecraftCore
{
	public enum QuestFailedReason
	{
		DONT_HAVE_REQ = 0,

		/// <summary>
		/// You are not high enough level for that quest.
		/// </summary>
		QUEST_FAILED_LOW_LEVEL = 1,

		/// <summary>
		/// That quest is not available to your race.
		/// </summary>
		QUEST_FAILED_WRONG_RACE = 6,

		/// <summary>
		/// You have completed that quest.
		/// </summary>
		QUEST_ALREADY_DONE = 7,

		/// <summary>
		/// You can only be on one timed quest at a time.
		/// </summary>
		QUEST_ONLY_ONE_TIMED = 12,

		/// <summary>
		/// You are already on that quest.
		/// </summary>
		QUEST_ALREADY_ON = 13,

		/// <summary>
		/// This quest requires an expansion enabled account.
		/// </summary>
		QUEST_FAILED_EXPANSION = 16,

		/// <summary>
		/// You are already on that quest.
		/// </summary>
		QUEST_ALREADY_ON2 = 18,

		/// <summary>
		/// You don't have the required items with you. Check storage.
		/// </summary>
		QUEST_FAILED_MISSING_ITEMS = 21,

		/// <summary>
		/// You don't have enough money for that quest.
		/// </summary>
		QUEST_FAILED_NOT_ENOUGH_MONEY = 23,

		/// <summary>
		/// You have already completed 25 daily quests today.
		/// </summary>
		DAILY_QUESTS_REMAINING = 26,

		/// <summary>
		/// You cannot complete quests once you have reached tired time.
		/// </summary>
		QUEST_FAILED_CAIS = 27,

		/// <summary>
		/// You have completed that daily quest today.
		/// </summary>
		DAILY_QUEST_COMPLETED_TODAY = 29
	};
}