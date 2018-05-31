using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_BATTLEFIELD_MGR_QUEUE_REQUEST_RESPONSE)]
[WireDataContractAttribute]
public sealed class SMSG_BATTLEFIELD_MGR_QUEUE_REQUEST_RESPONSE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_BATTLEFIELD_MGR_QUEUE_REQUEST_RESPONSE_DTO_PROXY()
    {
    }
}