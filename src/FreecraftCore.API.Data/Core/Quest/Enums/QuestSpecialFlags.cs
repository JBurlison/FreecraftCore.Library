using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Trinity flags for set SpecialFlags in DB if required but used only at server
	/// </summary>
	[Flags]
	public enum QuestSpecialFlags
	{
		NONE = 0x000,

		/// <summary>
		/// Set by 1 in SpecialFlags from DB
		/// </summary>
		REPEATABLE = 0x001,

		/// <summary>
		/// Set by 2 in SpecialFlags from DB (if required area explore, spell SPELL_EFFECT_QUEST_COMPLETE casting, table `FECT_QUEST_COMPLETE casting, table `*_script` command SCRIPT_COMMAND_QUEST_EXPLORED use, set from script)
		/// </summary>
		EXPLORATION_OR_EVENT = 0x002,

		/// <summary>
		/// Set by 4 in SpecialFlags in DB if the quest is to be auto-accepted.
		/// </summary>
		AUTO_ACCEPT = 0x004,

		/// <summary>
		/// Set by 8 in SpecialFlags in DB if the quest is used by Dungeon Finder.
		/// </summary>
		DF_QUEST = 0x008,

		/// <summary>
		/// Set by 16 in SpecialFlags in DB if the quest is reset at the begining of the month
		/// </summary>
		MONTHLY = 0x010,

		/// <summary>
		/// Set by 32 in SpecialFlags in DB if the quest requires RequiredOrNpcGo killcredit but NOT kill (a spell cast)
		/// </summary>
		CAST = 0x020,
											// room for more custom flags

		DB_ALLOWED = REPEATABLE | EXPLORATION_OR_EVENT | AUTO_ACCEPT | DF_QUEST | MONTHLY | CAST,

		/// <summary>
		/// Internal flag computed only
		/// </summary>
		DELIVER = 0x080,

		/// <summary>
		/// Internal flag computed only
		/// </summary>
		SPEAKTO = 0x100,

		/// <summary>
		/// Internal flag computed only
		/// </summary>
		KILL = 0x200,

		/// <summary>
		/// Internal flag computed only
		/// </summary>
		TIMED = 0x400,

		/// <summary>
		/// Internal flag computed only
		/// </summary>
		PLAYER_KILL = 0x800,

		/// <summary>
		/// Internal flag computed only
		/// </summary>
		COMPLETED_AT_START = 0x1000
	};
}
