using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_WORLD_STATE_UI_TIMER_UPDATE)]
[WireDataContractAttribute]
public sealed class CMSG_WORLD_STATE_UI_TIMER_UPDATE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_WORLD_STATE_UI_TIMER_UPDATE_DTO_PROXY()
    {
    }
}