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
}
