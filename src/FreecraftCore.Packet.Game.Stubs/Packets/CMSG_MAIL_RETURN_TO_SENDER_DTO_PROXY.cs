using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_MAIL_RETURN_TO_SENDER)]
[WireDataContractAttribute]
public sealed class CMSG_MAIL_RETURN_TO_SENDER_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_MAIL_RETURN_TO_SENDER_DTO_PROXY()
    {
    }
}