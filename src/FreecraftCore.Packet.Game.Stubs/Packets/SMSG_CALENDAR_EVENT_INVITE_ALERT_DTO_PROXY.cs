using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_CALENDAR_EVENT_INVITE_ALERT)]
[WireDataContractAttribute]
public sealed class SMSG_CALENDAR_EVENT_INVITE_ALERT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_CALENDAR_EVENT_INVITE_ALERT_DTO_PROXY()
    {
    }
}