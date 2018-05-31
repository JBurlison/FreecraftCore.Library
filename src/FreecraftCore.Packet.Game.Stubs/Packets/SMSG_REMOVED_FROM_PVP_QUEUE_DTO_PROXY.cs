using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_REMOVED_FROM_PVP_QUEUE)]
[WireDataContractAttribute]
public sealed class SMSG_REMOVED_FROM_PVP_QUEUE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_REMOVED_FROM_PVP_QUEUE_DTO_PROXY()
    {
    }
}