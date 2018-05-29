using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CALENDAR_EVENT_STATUS)]
[WireDataContractAttribute]
public sealed class CMSG_CALENDAR_EVENT_STATUS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CALENDAR_EVENT_STATUS_DTO_PROXY()
    {
    }
}