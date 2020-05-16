using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public interface IGDBCEnumerable<out TEntryType> : IEnumerable<TEntryType>
		where TEntryType : IDBCEntryIdentifiable
	{

	}
}
