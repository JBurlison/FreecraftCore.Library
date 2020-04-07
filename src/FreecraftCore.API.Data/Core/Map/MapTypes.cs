using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Lua_IsInInstance
	/// </summary>
	public enum MapTypes
	{
		/// <summary>
		/// none
		/// </summary>
		COMMON = 0,

		/// <summary>
		/// party
		/// </summary>
		INSTANCE = 1,

		/// <summary>
		/// raid
		/// </summary>
		RAID = 2,

		/// <summary>
		/// pvp
		/// </summary>
		BATTLEGROUND = 3,

		/// <summary>
		/// arena
		/// </summary>
		ARENA = 4 
	}
}
