namespace FreecraftCore
{
	/// <summary>
	/// Interface metadata market for game payloads.
	/// </summary>
	public interface IGamePacketPayload : IMessageVerifyable, IProtocolGroupable, IOperationCodeProvidable<NetworkOperationCode>
	{

	}
}
