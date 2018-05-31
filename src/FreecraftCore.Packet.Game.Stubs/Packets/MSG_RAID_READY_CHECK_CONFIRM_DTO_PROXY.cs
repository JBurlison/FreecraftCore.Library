using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_RAID_READY_CHECK_CONFIRM)]
[WireDataContractAttribute]
public sealed class MSG_RAID_READY_CHECK_CONFIRM_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_RAID_READY_CHECK_CONFIRM_DTO_PROXY()
    {
    }
}