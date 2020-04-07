using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for DBC types that define UI orderable elements.
	/// </summary>
	public interface IDBCUIOrderable
	{
		/// <summary>
		/// The UI order priority.
		/// </summary>
		int UIOrder { get; }
	}
}
