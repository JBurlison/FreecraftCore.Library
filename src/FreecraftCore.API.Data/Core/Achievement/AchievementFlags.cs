using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	[Flags]
	public enum AchievementFlags
	{
		/// <summary>
		///  Just count statistic (never stop and complete)
		/// </summary>
		COUNTER = 0x00000001,

		/// <summary>
		/// Not sent to client - internal use only
		/// </summary>
		HIDDEN = 0x00000002,

		/// <summary>
		/// Store only max value? used only in "Reach level xx"
		/// </summary>
		STORE_MAX_VALUE = 0x00000004,

		/// <summary>
		/// Use summ criteria value from all requirements (and calculate max value)
		/// </summary>
		SUMM = 0x00000008,

		/// <summary>
		/// Show max criteria (and calculate max value ??)
		/// </summary>
		MAX_USED = 0x00000010,

		/// <summary>
		/// Use not zero req count (and calculate max value)
		/// </summary>
		REQ_COUNT = 0x00000020,

		/// <summary>
		/// Show as average value (value / time_in_days) depend from other flag (by def use last criteria value)
		/// </summary>
		AVERAGE = 0x00000040,

		/// <summary>
		/// Show as progress bar (value / max vale) depend from other flag (by def use last criteria value)
		/// </summary>
		BAR = 0x00000080,

		REALM_FIRST_REACH = 0x00000100,
		REALM_FIRST_KILL = 0x00000200 
	}
}
