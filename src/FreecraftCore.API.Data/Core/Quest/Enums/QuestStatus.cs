namespace FreecraftCore
{
	public enum QuestStatus : byte
	{
		STATUS_NONE = 0,
		STATUS_COMPLETE = 1,
		//STATUS_UNAVAILABLE    = 2,
		STATUS_INCOMPLETE = 3,
		//STATUS_AVAILABLE      = 4,
		STATUS_FAILED = 5,
		STATUS_REWARDED = 6,        // Not used in DB
		MAX_QUEST_STATUS
	};
}