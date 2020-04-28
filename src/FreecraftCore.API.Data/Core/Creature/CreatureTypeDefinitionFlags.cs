using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Not to be confused with <see cref="CreatureTypeFlags"/> which is NOT a DBC-based enum.
	/// This enum is from <see cref="CreatureTypeEntry{TStringType}"/> the flags column.
	/// </summary>
	[Flags]
	public enum CreatureTypeDefinitionFlags
	{
		None = 0,
		
		/// <summary>
		/// Flag indicates that this creature type should be ignored
		/// for tab targetting searching.
		/// </summary>
		IgnoreTabTargetting = 1 << 0,
	}
}
