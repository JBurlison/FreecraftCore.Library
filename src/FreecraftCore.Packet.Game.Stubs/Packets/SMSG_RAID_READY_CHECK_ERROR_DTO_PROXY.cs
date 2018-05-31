using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_RAID_READY_CHECK_ERROR)]
[WireDataContractAttribute]
public sealed class SMSG_RAID_READY_CHECK_ERROR_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_RAID_READY_CHECK_ERROR_DTO_PROXY()
    {
    }
}