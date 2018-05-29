using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CALENDAR_ADD_EVENT)]
[WireDataContractAttribute]
public sealed class CMSG_CALENDAR_ADD_EVENT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CALENDAR_ADD_EVENT_DTO_PROXY()
    {
    }
}