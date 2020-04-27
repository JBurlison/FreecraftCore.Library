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
		/// Flag indicates that the creature type should reward no experience.
		/// </summary>
		NoExperience = 1 << 0,
	}
}
