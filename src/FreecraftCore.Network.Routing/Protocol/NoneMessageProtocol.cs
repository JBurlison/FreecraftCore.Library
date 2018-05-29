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
