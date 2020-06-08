using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for spell data that is temporally uniquely identifiable.
	/// </summary>
	public interface ITemporallyUniqueSpellDataIdentifiable
	{
		/// <summary>
		/// The spell id.
		/// </summary>
		int SpellId { get; }

		/// <summary>
		/// Represents a unique bit incremented each time a WoW client sends a spell cast request.
		/// This does not reset when switching characters or even logging out.
		/// It could be used in combination with <see cref="SpellId"/> to build a 64bit-ish temporally unique key for the spell cast.
		/// </summary>
		byte SpellCastCount { get; }
	}
}
