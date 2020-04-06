using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Enumeration of all player character races.
	/// </summary>
	[WireDataContract]
	public enum CharacterRace : byte
	{
		NONE = 0,
		HUMAN = 1,
		ORC = 2,
		DWARF = 3,
		NIGHTELF = 4,
		UNDEAD_PLAYER = 5,
		TAUREN = 6,
		GNOME = 7,
		TROLL = 8,
		//GOBLIN              = 9,
		BLOODELF = 10,
		DRAENEI = 11
		//FEL_ORC            = 12,
		//NAGA               = 13,
		//BROKEN             = 14,
		//SKELETON           = 15,
		//VRYKUL             = 16,
		//TUSKARR            = 17,
		//FOREST_TROLL       = 18,
		//TAUNKA             = 19,
		//NORTHREND_SKELETON = 20,
		//ICE_TROLL          = 21
	}
}
