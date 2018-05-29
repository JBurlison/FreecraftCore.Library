using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Enumeration of all gender states
	/// </summary>
	[WireDataContract]
	public enum CharacterGender : byte
	{
		Male = 0,
		Female = 1,
		Genderless = 2
	}
}
