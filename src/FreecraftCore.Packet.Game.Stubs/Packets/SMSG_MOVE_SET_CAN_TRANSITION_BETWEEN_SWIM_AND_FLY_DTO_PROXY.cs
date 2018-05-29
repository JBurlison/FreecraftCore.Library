using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_MOVE_SET_CAN_TRANSITION_BETWEEN_SWIM_AND_FLY)]
[WireDataContractAttribute]
public sealed class SMSG_MOVE_SET_CAN_TRANSITION_BETWEEN_SWIM_AND_FLY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_MOVE_SET_CAN_TRANSITION_BETWEEN_SWIM_AND_FLY_DTO_PROXY()
    {
    }
}