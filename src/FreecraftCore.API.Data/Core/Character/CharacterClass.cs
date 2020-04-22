using System;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Enumeration of all character classes.
	/// </summary>
	[WireDataContract]
	public enum CharacterClass : byte
	{
		Warrior = 1,
		Paladin = 2,
		Hunter = 3,
		Rogue = 4,
		Priest = 5,
		DeathKnight = 6,
		Shaman = 7,
		Mage = 8,
		Warlock = 9,
		Druid = 11,
	}

	[Flags]
	[WireDataContract]
	public enum CharacterClassMask : int
	{
		None = 0,
		Warrior = 1 << CharacterClass.Warrior - 1,
		Paladin = 1 << CharacterClass.Paladin - 1,
		Hunter = 1 << CharacterClass.Hunter - 1,
		Rogue = 1 << CharacterClass.Rogue - 1,
		Priest = 1 << CharacterClass.Priest - 1,
		DeathKnight = 1 << CharacterClass.DeathKnight - 1,
		Shaman = 1 << CharacterClass.Shaman - 1,
		Mage = 1 << CharacterClass.Mage - 1,
		Warlock = 1 << CharacterClass.Warlock - 1,
		Druid = 1 << CharacterClass.Druid - 1,
	}
}
