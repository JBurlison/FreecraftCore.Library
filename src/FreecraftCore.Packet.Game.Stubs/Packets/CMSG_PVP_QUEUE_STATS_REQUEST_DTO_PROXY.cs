using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_PVP_QUEUE_STATS_REQUEST)]
[WireDataContractAttribute]
public sealed class CMSG_PVP_QUEUE_STATS_REQUEST_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_PVP_QUEUE_STATS_REQUEST_DTO_PROXY()
    {
    }
}