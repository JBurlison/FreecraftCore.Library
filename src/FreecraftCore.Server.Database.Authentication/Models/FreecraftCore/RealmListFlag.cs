using System;

namespace FreecraftCore
{
	//See: https://trinitycore.atlassian.net/wiki/spaces/tc/pages/2130016/realmlist#realmlist-flag
	/// <summary>
	/// Enumeration of realm flags.
	/// </summary>
	[Flags]
	public enum RealmListFlag : byte
	{
		None = 0x0,

		//TODO: What is this one?
		Invalid = 0x1,

		Offline = 0x2,

		SpecifyBuild = 0x4,

		Medium = 0x8,

		Medium2 = 0xF,

		NewPlayers = 0x10,

		Recommended = 0x20,

		Full = 0x40
	}
}
