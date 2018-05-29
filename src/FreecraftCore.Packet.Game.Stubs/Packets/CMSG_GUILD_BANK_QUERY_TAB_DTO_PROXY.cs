using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_GUILD_BANK_QUERY_TAB)]
[WireDataContractAttribute]
public sealed class CMSG_GUILD_BANK_QUERY_TAB_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_GUILD_BANK_QUERY_TAB_DTO_PROXY()
    {
    }
}