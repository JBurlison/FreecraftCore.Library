namespace FreecraftCore
{
	/// <summary>
	/// The header for authentication packets.
	/// </summary>
	public interface IAuthenticationPacketHeader : IMessageVerifyable, IOperationIdentifable<AuthOperationCode>
	{

	}
}
