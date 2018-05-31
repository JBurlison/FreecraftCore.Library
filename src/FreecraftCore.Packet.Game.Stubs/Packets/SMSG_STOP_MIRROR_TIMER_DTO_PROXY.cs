using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_STOP_MIRROR_TIMER)]
[WireDataContractAttribute]
public sealed class SMSG_STOP_MIRROR_TIMER_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_STOP_MIRROR_TIMER_DTO_PROXY()
    {
    }
}