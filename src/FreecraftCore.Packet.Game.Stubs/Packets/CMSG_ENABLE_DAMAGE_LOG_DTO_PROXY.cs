using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_ENABLE_DAMAGE_LOG)]
[WireDataContractAttribute]
public sealed class CMSG_ENABLE_DAMAGE_LOG_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_ENABLE_DAMAGE_LOG_DTO_PROXY()
    {
    }
}