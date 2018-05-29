namespace FreecraftCore
{
	public interface IAuthenticationPacket : INetworkPacket<AuthOperationCode, IAuthenticationPacketHeader, AuthenticationServerPayload>
	{

	}
}
