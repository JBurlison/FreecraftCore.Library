using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CALENDAR_COMPLAIN)]
[WireDataContractAttribute]
public sealed class CMSG_CALENDAR_COMPLAIN_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CALENDAR_COMPLAIN_DTO_PROXY()
    {
    }
}