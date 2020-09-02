using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	// byte value (UNIT_FIELD_BYTES_1, 0)
	public enum UnitStandStateType
	{
		STATE_STAND = 0,
		STATE_SIT = 1,
		STATE_SIT_CHAIR = 2,
		STATE_SLEEP = 3,
		STATE_SIT_LOW_CHAIR = 4,
		STATE_SIT_MEDIUM_CHAIR = 5,
		STATE_SIT_HIGH_CHAIR = 6,
		STATE_DEAD = 7,
		STATE_KNEEL = 8,
		STATE_SUBMERGED = 9
	}
}
