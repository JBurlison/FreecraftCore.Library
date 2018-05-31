using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_LEARN_PREVIEW_TALENTS)]
[WireDataContractAttribute]
public sealed class CMSG_LEARN_PREVIEW_TALENTS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_LEARN_PREVIEW_TALENTS_DTO_PROXY()
    {
    }
}