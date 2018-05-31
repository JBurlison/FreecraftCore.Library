using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_MAIL_MARK_AS_READ)]
[WireDataContractAttribute]
public sealed class CMSG_MAIL_MARK_AS_READ_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
{
    [ReadToEndAttribute]
    [WireMemberAttribute(1)]
    private byte[] _Data;
    public byte[] Data
    {
        get
        {
            return _Data;
        }

        set
        {
            _Data = value;
        }
    }

    public CMSG_MAIL_MARK_AS_READ_DTO_PROXY()
    {
    }
}