using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_GMRESPONSE_RESOLVE)]
[WireDataContractAttribute]
public sealed class CMSG_GMRESPONSE_RESOLVE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_GMRESPONSE_RESOLVE_DTO_PROXY()
    {
    }
}