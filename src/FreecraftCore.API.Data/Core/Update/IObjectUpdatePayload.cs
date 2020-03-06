using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for payloads that are involved in object updates.
	/// </summary>
	public interface IObjectUpdatePayload
	{
		/// <summary>
		/// The update block collection.
		/// </summary>
		UpdateBlockCollection UpdateBlocks { get; }
	}
}
