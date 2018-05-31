using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_OPT_OUT_OF_LOOT)]
[WireDataContractAttribute]
public sealed class CMSG_OPT_OUT_OF_LOOT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_OPT_OUT_OF_LOOT_DTO_PROXY()
    {
    }
}