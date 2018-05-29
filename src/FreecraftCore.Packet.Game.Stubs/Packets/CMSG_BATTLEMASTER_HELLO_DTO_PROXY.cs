using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_BATTLEMASTER_HELLO)]
[WireDataContractAttribute]
public sealed class CMSG_BATTLEMASTER_HELLO_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_BATTLEMASTER_HELLO_DTO_PROXY()
    {
    }
}