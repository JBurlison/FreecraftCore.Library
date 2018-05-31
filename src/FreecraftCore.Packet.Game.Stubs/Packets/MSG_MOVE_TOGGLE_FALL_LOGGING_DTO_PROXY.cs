using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_MOVE_TOGGLE_FALL_LOGGING)]
[WireDataContractAttribute]
public sealed class MSG_MOVE_TOGGLE_FALL_LOGGING_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_MOVE_TOGGLE_FALL_LOGGING_DTO_PROXY()
    {
    }
}