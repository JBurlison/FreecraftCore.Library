using System;

namespace FreecraftCore
{
	/// <summary>
	/// Flags used at server and sent to client
	/// </summary>
	[Flags]
	public enum QuestFlags
	{
		NONE = 0x00000000,

		/// <summary>
		/// Not used currently.
		/// </summary>
		STAY_ALIVE = 0x00000001,

		/// <summary>
		/// Not used currently. If player in party, all players that can accept this quest will receive confirmation box to accept quest CMSG_QUEST_CONFIRM_ACCEPT/SMSG_QUEST_CONFIRM_ACCEPT
		/// </summary>
		PARTY_ACCEPT = 0x00000002,

		/// <summary>
		/// Not used currently.
		/// </summary>
		EXPLORATION = 0x00000004,

		/// <summary>
		/// Can be shared: Player::CanShareQuest()
		/// </summary>
		SHARABLE = 0x00000008,

		/// <summary>
		/// Not used currently
		/// </summary>
		HAS_CONDITION = 0x00000010,

		/// <summary>
		/// Not used currently: Unsure of content
		/// </summary>
		HIDE_REWARD_POI = 0x00000020,

		/// <summary>
		/// Can be completed while in raid
		/// </summary>
		RAID = 0x00000040,

		/// <summary>
		/// Not used currently: Available if TBC expansion enabled only
		/// </summary>
		TBC = 0x00000080,

		/// <summary>
		/// Not used currently: Experience is not converted to gold at max level
		/// </summary>
		NO_MONEY_FROM_XP = 0x00000100,

		/// <summary>
		/// Items and money rewarded only sent in SMSG_QUESTGIVER_OFFER_REWARD (not in SMSG_QUESTGIVER_QUEST_DETAILS or in client quest log(SMSG_QUEST_QUERY_RESPONSE))
		/// </summary>
		HIDDEN_REWARDS = 0x00000200,

		/// <summary>
		/// These quests are automatically rewarded on quest complete and they will never appear in quest log client side.
		/// </summary>
		TRACKING = 0x00000400,

		/// <summary>
		/// Not used currently
		/// </summary>
		DEPRECATE_REPUTATION = 0x00000800,

		/// <summary>
		///  Used to know quest is Daily one
		/// </summary>
		DAILY = 0x00001000,

		/// <summary>
		/// Having this quest in log forces PvP flag
		/// </summary>
		FLAGS_PVP = 0x00002000,

		/// <summary>
		/// Used on quests that are not generically available
		/// </summary>
		UNAVAILABLE = 0x00004000,
		WEEKLY = 0x00008000,

		/// <summary>
		/// auto complete
		/// </summary>
		AUTOCOMPLETE = 0x00010000,

		/// <summary>
		/// Displays usable item in quest tracker
		/// </summary>
		DISPLAY_ITEM_IN_TRACKER = 0x00020000,

		/// <summary>
		/// use Objective text as Complete text
		/// </summary>
		OBJ_TEXT = 0x00040000,

		/// <summary>
		/// The client recognizes this flag as auto-accept. However, NONE of the current quests (3.3.5a) have this flag. Maybe blizz used to use it, or will use it in the future.
		/// </summary>
		AUTO_ACCEPT = 0x00080000,

		// ... 4.x added flags up to 0x80000000 - all unknown for now
	};
}