using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_SET_GUILD_BANK_TEXT)]
[WireDataContractAttribute]
public sealed class CMSG_SET_GUILD_BANK_TEXT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_SET_GUILD_BANK_TEXT_DTO_PROXY()
    {
    }
}