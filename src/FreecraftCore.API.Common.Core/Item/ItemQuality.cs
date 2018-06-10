using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Enumeration of item qualities.
	/// </summary>
	public enum ItemQuality : int
	{
		ITEM_QUALITY_POOR = 0,                 //GREY
		ITEM_QUALITY_NORMAL = 1,                 //WHITE
		ITEM_QUALITY_UNCOMMON = 2,                 //GREEN
		ITEM_QUALITY_RARE = 3,                 //BLUE
		ITEM_QUALITY_EPIC = 4,                 //PURPLE
		ITEM_QUALITY_LEGENDARY = 5,                 //ORANGE
		ITEM_QUALITY_ARTIFACT = 6,                 //LIGHT YELLOW
		ITEM_QUALITY_HEIRLOOM = 7
	}
}
