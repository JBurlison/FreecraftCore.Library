using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_SET_ARENA_TEAM_RATING_BY_INDEX)]
[WireDataContractAttribute]
public sealed class CMSG_SET_ARENA_TEAM_RATING_BY_INDEX_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
{
    [ReadToEndAttribute]
    [WireMemberAttribute(1)]
    private byte[] _Data;
    public byte[] Data
    {
        get
        {
            return Data;
        }

        set
        {
            Data = value;
        }
    }

    public CMSG_SET_ARENA_TEAM_RATING_BY_INDEX_DTO_PROXY()
    {
    }
}