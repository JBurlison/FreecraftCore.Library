using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	[Flags]
	public enum CharacterClassEquipmentFlags
	{
		CanWearLeather = 1 << 0,
		CanWearCloth = 1 << 1,
		CanSummonPets = 1 << 2,
		UsesRelic = 1 << 3,
		CanWearMail = 1 << 4,
		CanWearPlate = 1 << 5
	}
}
