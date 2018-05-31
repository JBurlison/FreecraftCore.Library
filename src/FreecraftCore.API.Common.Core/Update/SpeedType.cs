using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace FreecraftCore
{
	/// <summary>
	/// Enumeration of speed types.
	/// </summary>
	public enum SpeedType : byte
	{
		Walk = 0,
		Run = 1,
		RunBack = 2,
		Swim = 3,
		SwimBack = 4,
		Turn = 5,
		Fly = 6,
		FlyBack = 7,
		Pitch = 8
	}
}
