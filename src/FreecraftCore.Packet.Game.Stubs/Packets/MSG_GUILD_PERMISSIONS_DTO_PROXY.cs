using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_GUILD_PERMISSIONS)]
[WireDataContractAttribute]
public sealed class MSG_GUILD_PERMISSIONS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
{
    [ReadToEndAttribute]
    [WireMemberAttribute(1)]
    private byte[] _Data;
    public byte[] Data
    {
        get
        {
            return Data;
        }

        set
        {
            Data = value;
        }
    }

    public MSG_GUILD_PERMISSIONS_DTO_PROXY()
    {
    }
}