namespace FreecraftCore
{
	/// <summary>
	/// Strongly typed <see cref="IMessageProtocolStrategy"/> that provides the
	/// <see cref="ProtocolCode"/> for auth messages.
	/// </summary>
	public sealed class AuthenticationMessageProtocol : IMessageProtocolStrategy
	{
		/// <inheritdoc />
		public ProtocolCode MessageProtocol => ProtocolCode.Authentication;

		public AuthenticationMessageProtocol()
		{
			
		}
	}
}
