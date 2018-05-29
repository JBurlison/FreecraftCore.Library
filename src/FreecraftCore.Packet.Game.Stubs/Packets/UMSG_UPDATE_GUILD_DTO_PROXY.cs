using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.UMSG_UPDATE_GUILD)]
[WireDataContractAttribute]
public sealed class UMSG_UPDATE_GUILD_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public UMSG_UPDATE_GUILD_DTO_PROXY()
    {
    }
}