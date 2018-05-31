using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_SPIRIT_HEALER_ACTIVATE)]
[WireDataContractAttribute]
public sealed class CMSG_SPIRIT_HEALER_ACTIVATE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_SPIRIT_HEALER_ACTIVATE_DTO_PROXY()
    {
    }
}