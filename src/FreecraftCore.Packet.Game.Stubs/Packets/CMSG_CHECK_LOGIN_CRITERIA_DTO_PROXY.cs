using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CHECK_LOGIN_CRITERIA)]
[WireDataContractAttribute]
public sealed class CMSG_CHECK_LOGIN_CRITERIA_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CHECK_LOGIN_CRITERIA_DTO_PROXY()
    {
    }
}