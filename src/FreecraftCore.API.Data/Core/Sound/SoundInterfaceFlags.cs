using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	//From: https://wowdev.wiki/DB/SoundEntries
	public enum SoundInterfaceFlags
	{
		/// <summary>
		/// Still seen in file for a lot of spells
		/// </summary>
		UNUSED_1 = 0x0001, 
		UNUSED_2 = 0x0002,
		UNUSED_3 = 0x0004,
		UNUSED_4 = 0x0008,
		UNUSED_5 = 0x0010,

		/// <summary>
		/// Client prevents the same sound overlapping
		/// </summary>
		NO_DUPLICATES = 0x0020,
		UNUSED_6 = 0x0040,
		UNUSED_7 = 0x0080,
		UNUSED_8 = 0x0100,
		LOOPING = 0x0200,
		VARY_PITCH = 0x0400,
		VARY_VOLUME = 0x0800,
		UNUSED_9 = 0x1000,
	}
}
