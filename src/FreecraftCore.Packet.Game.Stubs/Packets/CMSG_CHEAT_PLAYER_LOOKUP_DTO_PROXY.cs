using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CHEAT_PLAYER_LOOKUP)]
[WireDataContractAttribute]
public sealed class CMSG_CHEAT_PLAYER_LOOKUP_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CHEAT_PLAYER_LOOKUP_DTO_PROXY()
    {
    }
}