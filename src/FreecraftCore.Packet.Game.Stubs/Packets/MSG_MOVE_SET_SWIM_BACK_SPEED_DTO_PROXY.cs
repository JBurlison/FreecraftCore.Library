using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_MOVE_SET_SWIM_BACK_SPEED)]
[WireDataContractAttribute]
public sealed class MSG_MOVE_SET_SWIM_BACK_SPEED_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_MOVE_SET_SWIM_BACK_SPEED_DTO_PROXY()
    {
    }
}