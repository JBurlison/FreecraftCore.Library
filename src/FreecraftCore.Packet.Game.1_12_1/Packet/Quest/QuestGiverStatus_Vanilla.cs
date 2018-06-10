using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	//Mangos sends this as a byte
	/// <summary>
	/// The 1.12.1 status for quest givers.
	/// </summary>
	public enum QuestGiverStatus_Vanilla : byte
	{
		DIALOG_STATUS_NONE = 0,
		DIALOG_STATUS_UNAVAILABLE = 1,
		DIALOG_STATUS_CHAT = 2,
		DIALOG_STATUS_INCOMPLETE = 3,
		DIALOG_STATUS_REWARD_REP = 4,
		DIALOG_STATUS_AVAILABLE = 5,
		DIALOG_STATUS_REWARD_OLD = 6,             // red dot on minimap
		DIALOG_STATUS_REWARD2 = 7,             // yellow dot on minimap
		// [-ZERO] tbc?  DIALOG_STATUS_REWARD                   = 8              // yellow dot on minimap
		DIALOG_STATUS_UNDEFINED = 100            // Used as result for unassigned ScriptCall
	}
}
