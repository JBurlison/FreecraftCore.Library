using System;

namespace FreecraftCore
{
	/// <summary>
	/// Sent in <see cref="EPlayerFields"/> Quest State.
	/// </summary>
	[Flags]
	public enum QuestSlotStateMask
	{
		NONE = 0x0000,
		COMPLETE = 0x0001,
		FAIL = 0x0002
	};
}