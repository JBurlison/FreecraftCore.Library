using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_SPLINE_MOVE_SET_WALK_MODE)]
[WireDataContractAttribute]
public sealed class SMSG_SPLINE_MOVE_SET_WALK_MODE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_SPLINE_MOVE_SET_WALK_MODE_DTO_PROXY()
    {
    }
}