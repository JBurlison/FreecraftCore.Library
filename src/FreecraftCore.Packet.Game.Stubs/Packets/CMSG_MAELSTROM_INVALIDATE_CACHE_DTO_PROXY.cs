using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_MAELSTROM_INVALIDATE_CACHE)]
[WireDataContractAttribute]
public sealed class CMSG_MAELSTROM_INVALIDATE_CACHE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_MAELSTROM_INVALIDATE_CACHE_DTO_PROXY()
    {
    }
}