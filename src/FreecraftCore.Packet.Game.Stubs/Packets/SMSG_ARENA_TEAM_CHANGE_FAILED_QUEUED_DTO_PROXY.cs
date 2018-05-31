using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_ARENA_TEAM_CHANGE_FAILED_QUEUED)]
[WireDataContractAttribute]
public sealed class SMSG_ARENA_TEAM_CHANGE_FAILED_QUEUED_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_ARENA_TEAM_CHANGE_FAILED_QUEUED_DTO_PROXY()
    {
    }
}