using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_DEBUG_SERVER_GEO)]
[WireDataContractAttribute]
public sealed class CMSG_DEBUG_SERVER_GEO_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_DEBUG_SERVER_GEO_DTO_PROXY()
    {
    }
}