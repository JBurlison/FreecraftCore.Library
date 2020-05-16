using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for types that provide access to GDBC entries.
	/// </summary>
	/// <typeparam name="TEntryType">The entry type.</typeparam>
	public interface IGDBCCollection<TEntryType> : IGDBCEnumerable<TEntryType>, IGDBCDictionary<TEntryType>
		where TEntryType : IDBCEntryIdentifiable
	{
		/// <summary>
		/// Indicates if the GDBC collection is fully initialized and ready for access.
		/// </summary>
		bool isInitialized { get; }

		/// <summary>
		/// Initializes the GDBC collection for use.
		/// </summary>
		void Initialize();
	}
}
