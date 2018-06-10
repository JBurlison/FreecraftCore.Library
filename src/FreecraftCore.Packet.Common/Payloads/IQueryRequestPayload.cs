using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for payloads that are query requests.
	/// </summary>
	public interface IQueryRequestPayload
	{
		/// <summary>
		/// The ID of the query.
		/// </summary>
		int QueryId { get; }

		/// <summary>
		/// The GUID for the query.
		/// </summary>
		ObjectGuid QueryGuid { get; }
	}
}
