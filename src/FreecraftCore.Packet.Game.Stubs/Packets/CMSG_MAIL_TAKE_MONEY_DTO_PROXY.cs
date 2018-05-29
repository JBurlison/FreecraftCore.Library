using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_MAIL_TAKE_MONEY)]
[WireDataContractAttribute]
public sealed class CMSG_MAIL_TAKE_MONEY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_MAIL_TAKE_MONEY_DTO_PROXY()
    {
    }
}