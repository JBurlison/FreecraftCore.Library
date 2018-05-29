using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_ARENA_TEAM_DISBAND)]
[WireDataContractAttribute]
public sealed class CMSG_ARENA_TEAM_DISBAND_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_ARENA_TEAM_DISBAND_DTO_PROXY()
    {
    }
}