using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreecraftCore;

namespace FreecraftCore
{
	/// <summary>
	/// Strongly typed <see cref="IMessageProtocolStrategy"/> that provides the
	/// <see cref="ProtocolCode"/> for messages with no protocol grouping.
	/// </summary>
	public sealed class NoneMessageProtocol : IMessageProtocolStrategy
	{
		/// <inheritdoc />
		public ProtocolCode MessageProtocol => ProtocolCode.None;

		public NoneMessageProtocol()
		{
			
		}
	}
}
