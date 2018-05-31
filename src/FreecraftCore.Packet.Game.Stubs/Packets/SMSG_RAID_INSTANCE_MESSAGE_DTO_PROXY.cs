using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_RAID_INSTANCE_MESSAGE)]
[WireDataContractAttribute]
public sealed class SMSG_RAID_INSTANCE_MESSAGE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_RAID_INSTANCE_MESSAGE_DTO_PROXY()
    {
    }
}