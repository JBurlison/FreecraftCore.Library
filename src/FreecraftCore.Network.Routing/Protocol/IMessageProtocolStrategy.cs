namespace FreecraftCore
{
	/// <summary>
	/// Contract for a strongly typed strategy that provides a <see cref="ProtocolCode"/>.
	/// </summary>
	public interface IMessageProtocolStrategy
	{
		ProtocolCode MessageProtocol { get; }
	}
}
