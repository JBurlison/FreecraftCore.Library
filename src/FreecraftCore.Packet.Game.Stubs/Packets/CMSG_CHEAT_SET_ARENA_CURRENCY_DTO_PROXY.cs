using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CHEAT_SET_ARENA_CURRENCY)]
[WireDataContractAttribute]
public sealed class CMSG_CHEAT_SET_ARENA_CURRENCY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CHEAT_SET_ARENA_CURRENCY_DTO_PROXY()
    {
    }
}