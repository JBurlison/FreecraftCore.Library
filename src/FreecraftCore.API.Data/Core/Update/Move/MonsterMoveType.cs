namespace FreecraftCore
{
	/// <summary>
	/// Enumeration of monster movement types.
	/// </summary>
	public enum MonsterMoveType : byte
	{
		MonsterMoveNormal = 0,
		MonsterMoveStop = 1,
		MonsterMoveFacingSpot = 2,
		MonsterMoveFacingTarget = 3,
		MonsterMoveFacingAngle = 4
	}
}