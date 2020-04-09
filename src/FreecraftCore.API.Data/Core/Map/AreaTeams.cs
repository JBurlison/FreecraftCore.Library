using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	[Flags]
	public enum AreaTeams
	{
		AREATEAM_NONE = 0,
		AREATEAM_ALLY = 2,
		AREATEAM_HORDE = 4,
		AREATEAM_ANY = 6
	}
}
