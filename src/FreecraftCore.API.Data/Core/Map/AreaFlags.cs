using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
    [Flags]
    public enum AreaFlags
    {
        /// <summary>
        /// Unknown
        /// </summary>
        AREA_FLAG_UNK0 = 0x00000001,

        /// <summary>
        /// Razorfen Downs, Naxxramas and Acherus: The Ebon Hold (3.3.5a)
        /// </summary>
        AREA_FLAG_UNK1 = 0x00000002,

        /// <summary>
        /// Only used for areas on map 571 (development before)
        /// </summary>
        AREA_FLAG_UNK2 = 0x00000004,

        /// <summary>
        /// city and city subsones
        /// </summary>
        AREA_FLAG_SLAVE_CAPITAL = 0x00000008,

        /// <summary>
        /// can't find common meaning
        /// </summary>
        AREA_FLAG_UNK3 = 0x00000010,

        /// <summary>
        /// slave capital city flag?
        /// </summary>
        AREA_FLAG_SLAVE_CAPITAL2 = 0x00000020,

        /// <summary>
        /// allow to duel here
        /// </summary>
        AREA_FLAG_ALLOW_DUELS = 0x00000040,

        /// <summary>
        /// arena, both instanced and world arenas
        /// </summary>
        AREA_FLAG_ARENA = 0x00000080,

        /// <summary>
        /// main capital city flag
        /// </summary>
        AREA_FLAG_CAPITAL = 0x00000100,

        /// <summary>
        /// only for one zone named "City" (where it located?)
        /// </summary>
        AREA_FLAG_CITY = 0x00000200,

        /// <summary>
        /// expansion zones? (only Eye of the Storm not have this flag, but have 0x00004000 flag)
        /// </summary>
        AREA_FLAG_OUTLAND = 0x00000400,

        /// <summary>
        /// sanctuary area (PvP disabled)
        /// </summary>
        AREA_FLAG_SANCTUARY = 0x00000800,

        /// <summary>
        /// Respawn alive at the graveyard without corpse
        /// </summary>
        AREA_FLAG_NEED_FLY = 0x00001000,

        /// <summary>
        /// Unused in 3.3.5a
        /// </summary>
        AREA_FLAG_UNUSED1 = 0x00002000,

        /// <summary>
        /// expansion zones? (only Circle of Blood Arena not have this flag, but have 0x00000400 flag)
        /// </summary>
        AREA_FLAG_OUTLAND2 = 0x00004000,

        /// <summary>
        /// pvp objective area? (Death's Door also has this flag although it's no pvp object area)
        /// </summary>
        AREA_FLAG_OUTDOOR_PVP = 0x00008000,

        /// <summary>
        /// used by instanced arenas only
        /// </summary>
        AREA_FLAG_ARENA_INSTANCE = 0x00010000,

        /// <summary>
        /// Unused in 3.3.5a
        /// </summary>
        AREA_FLAG_UNUSED2 = 0x00020000,

        /// <summary>
        /// On PvP servers these areas are considered contested, even though the zone it is contained in is a Horde/Alliance territory.
        /// </summary>
        AREA_FLAG_CONTESTED_AREA = 0x00040000,

        /// <summary>
        /// Valgarde and Acherus: The Ebon Hold
        /// </summary>
        AREA_FLAG_UNK4 = 0x00080000,

        /// <summary>
        /// used for some starting areas with area_level <= 15
        /// </summary>
        AREA_FLAG_LOWLEVEL = 0x00100000,

        /// <summary>
        /// small towns with Inn
        /// </summary>
        AREA_FLAG_TOWN = 0x00200000,

        /// <summary>
        /// Instead of using areatriggers, the zone will act as one for Horde players (Warsong Hold, Acherus: The Ebon Hold, New Agamand Inn, Vengeance Landing Inn, Sunreaver Pavilion, etc)
        /// </summary>
        AREA_FLAG_REST_ZONE_HORDE = 0x00400000,

        /// <summary>
        /// Instead of using areatriggers, the zone will act as one for Alliance players (Valgarde, Acherus: The Ebon Hold, Westguard Inn, Silver Covenant Pavilion, etc)
        /// </summary>
        AREA_FLAG_REST_ZONE_ALLIANCE = 0x00800000,

        /// <summary>
        /// Wintergrasp and it's subzones
        /// </summary>
        AREA_FLAG_WINTERGRASP = 0x01000000,

        /// <summary>
        /// used for determinating spell related inside/outside questions in Map::IsOutdoors
        /// </summary>
        AREA_FLAG_INSIDE = 0x02000000,

        /// <summary>
        /// used for determinating spell related inside/outside questions in Map::IsOutdoors
        /// </summary>
        AREA_FLAG_OUTSIDE = 0x04000000,

        /// <summary>
        /// Can Hearth And Resurrect From Area
        /// </summary>
        AREA_FLAG_WINTERGRASP_2 = 0x08000000,

        /// <summary>
        /// Marks zones where you cannot fly
        /// </summary>
        AREA_FLAG_NO_FLY_ZONE = 0x20000000, 

        AREA_RESTED_ALLOWED = AREA_FLAG_CAPITAL | AREA_FLAG_CITY | AREA_FLAG_SANCTUARY | AREA_FLAG_TOWN | AREA_FLAG_REST_ZONE_HORDE | AREA_FLAG_REST_ZONE_ALLIANCE
    };
}
