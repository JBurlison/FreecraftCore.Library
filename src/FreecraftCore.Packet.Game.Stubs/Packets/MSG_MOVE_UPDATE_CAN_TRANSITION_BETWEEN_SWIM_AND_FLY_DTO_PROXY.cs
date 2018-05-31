using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_MOVE_UPDATE_CAN_TRANSITION_BETWEEN_SWIM_AND_FLY)]
[WireDataContractAttribute]
public sealed class MSG_MOVE_UPDATE_CAN_TRANSITION_BETWEEN_SWIM_AND_FLY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_MOVE_UPDATE_CAN_TRANSITION_BETWEEN_SWIM_AND_FLY_DTO_PROXY()
    {
    }
}