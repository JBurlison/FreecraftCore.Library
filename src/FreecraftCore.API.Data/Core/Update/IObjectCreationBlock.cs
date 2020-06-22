using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public interface IObjectCreationBlock : IUpdateBlockChunk
	{
		/// <summary>
		/// The data about the creation request.
		/// </summary>
		ObjectCreationData CreationData { get; }
	}
}
