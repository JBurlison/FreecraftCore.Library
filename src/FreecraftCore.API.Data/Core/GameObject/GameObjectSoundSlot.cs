using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public static class GameObjectSoundSlotConstants
	{
		//SOUND_SLOT_COUNT, // = 10
		public const int MAX_COUNT = 10;
	}

	public enum GameObjectSoundSlot
	{
		Stand = 0,
		Open = 1,
		Loop = 2,
		Close = 3,
		Destroy = 4,
		Opened = 5,
		Custom0 = 6,
		Custom1 = 7,
		Custom2 = 8,
		Custom3 = 9
	};
}
