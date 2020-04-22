using System;
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

	[Flags]
	[WireDataContract]
	public enum CharacterRaceMask : int
	{
		NONE = 0,
		HUMAN = 1 << CharacterRace.HUMAN - 1,
		ORC = 1 << CharacterRace.ORC - 1,
		DWARF = 1 << CharacterRace.DWARF - 1,
		NIGHTELF = 1 << CharacterRace.NIGHTELF - 1,
		UNDEAD_PLAYER = 1 << CharacterRace.UNDEAD_PLAYER - 1,
		TAUREN = 1 << CharacterRace.TAUREN - 1,
		GNOME = 1 << CharacterRace.GNOME - 1,
		TROLL = 1 << CharacterRace.TROLL - 1,
		//GOBLIN              = 9,
		BLOODELF = 1 << CharacterRace.BLOODELF - 1,
		DRAENEI = 1 << CharacterRace.DRAENEI - 1
	}
}
