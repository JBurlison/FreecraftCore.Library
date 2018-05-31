using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_FLIGHT_SPLINE_SYNC)]
[WireDataContractAttribute]
public sealed class SMSG_FLIGHT_SPLINE_SYNC_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_FLIGHT_SPLINE_SYNC_DTO_PROXY()
    {
    }
}