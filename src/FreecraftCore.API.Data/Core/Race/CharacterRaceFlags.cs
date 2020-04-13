using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	//Based: https://wowdev.wiki/DB/ChrRaces
	[Flags]
	public enum CharacterRaceFlags
	{
		NotPlayable = 0x01,
		BareFeet = 0x02,
		CanMount = 0x08
	}
}
