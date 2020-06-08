using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public static class ITemporallyUniqueSpellDataIdentifiableExtensions
	{
		/// <summary>
		/// Computes a temporally unique identifier from the provided <see cref="ITemporallyUniqueSpellDataIdentifiable"/> data.
		/// </summary>
		/// <param name="data">Temporally unique spell data.</param>
		/// <returns>Long key that will be unique within a short time window.</returns>
		public static long CalculateTemporallyUniqueKey([NotNull] this ITemporallyUniqueSpellDataIdentifiable data)
		{
			if(data == null) throw new ArgumentNullException(nameof(data));

			return (long)data.SpellCastCount << 32 | (long)data.SpellId;
		}
	}
}
