using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for query payload types.
	/// </summary>
	public interface IQueryResponsePayload
	{
		/// <summary>
		/// The id of the query.
		/// </summary>
		int QueryId { get; }

		/// <summary>
		/// Indicates if the query was successful.
		/// </summary>
		bool IsSuccessful { get; }
	}

	public interface IQueryResponsePayload<out TResponseResultType> : IQueryResponsePayload
	{
		/// <summary>
		/// The result of the query.
		/// (Contract allows for null responses if <see cref="IsSuccessful"/>
		/// is false.
		/// </summary>
		TResponseResultType Result { get; }
	}
}
