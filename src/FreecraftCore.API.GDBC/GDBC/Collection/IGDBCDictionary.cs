using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public interface IGDBCDictionary<TEntryType> : IReadOnlyDictionary<int, TEntryType>
		where TEntryType : IDBCEntryIdentifiable
	{

	}
}
