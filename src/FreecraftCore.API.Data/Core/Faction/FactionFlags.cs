using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	[Flags]
	public enum FactionFlags
	{
		/// <summary>
		/// No faction flag
		/// </summary>
		FACTION_FLAG_NONE = 0x00,

		/// <summary>
		/// Makes visible in client (set or can be set at interaction with target of this faction)
		/// </summary>
		FACTION_FLAG_VISIBLE = 0x01,

		/// <summary>
		/// Enable AtWar-button in client. player controlled (except opposition team always war state), Flag only set on initial creation
		/// </summary>
		FACTION_FLAG_AT_WAR = 0x02,

		/// <summary>
		/// Hidden faction from reputation pane in client (player can gain reputation, but this update not sent to client)
		/// </summary>
		FACTION_FLAG_HIDDEN = 0x04,

		/// <summary>
		/// Always overwrite FACTION_FLAG_VISIBLE and hide faction in rep.list, used for hide opposite team factions
		/// </summary>
		FACTION_FLAG_INVISIBLE_FORCED = 0x08,

		/// <summary>
		/// Always overwrite FACTION_FLAG_AT_WAR, used for prevent war with own team factions
		/// </summary>
		FACTION_FLAG_PEACE_FORCED = 0x10,

		/// <summary>
		/// Player controlled, state stored in characters.data (CMSG_SET_FACTION_INACTIVE)
		/// </summary>
		FACTION_FLAG_INACTIVE = 0x20,

		/// <summary>
		/// Flag for the two competing outland factions
		/// </summary>
		FACTION_FLAG_RIVAL = 0x40,

		/// <summary>
		/// Horde and alliance home cities and their northrend allies have this flag
		/// </summary>
		FACTION_FLAG_SPECIAL = 0x80
	};

}
