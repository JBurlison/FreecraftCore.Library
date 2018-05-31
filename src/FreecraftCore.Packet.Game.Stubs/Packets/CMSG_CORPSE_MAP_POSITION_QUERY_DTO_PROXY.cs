using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CORPSE_MAP_POSITION_QUERY)]
[WireDataContractAttribute]
public sealed class CMSG_CORPSE_MAP_POSITION_QUERY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CORPSE_MAP_POSITION_QUERY_DTO_PROXY()
    {
    }
}