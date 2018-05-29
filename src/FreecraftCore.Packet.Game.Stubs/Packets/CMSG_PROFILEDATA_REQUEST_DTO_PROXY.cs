using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_PROFILEDATA_REQUEST)]
[WireDataContractAttribute]
public sealed class CMSG_PROFILEDATA_REQUEST_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_PROFILEDATA_REQUEST_DTO_PROXY()
    {
    }
}