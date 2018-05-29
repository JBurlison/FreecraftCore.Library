using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_GMTICKET_DELETETICKET)]
[WireDataContractAttribute]
public sealed class CMSG_GMTICKET_DELETETICKET_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_GMTICKET_DELETETICKET_DTO_PROXY()
    {
    }
}