using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_BATTLEFIELD_MGR_QUEUE_INVITE)]
[WireDataContractAttribute]
public sealed class SMSG_BATTLEFIELD_MGR_QUEUE_INVITE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_BATTLEFIELD_MGR_QUEUE_INVITE_DTO_PROXY()
    {
    }
}