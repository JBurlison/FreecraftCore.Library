using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_BATTLEGROUND_PLAYER_POSITIONS)]
[WireDataContractAttribute]
public sealed class MSG_BATTLEGROUND_PLAYER_POSITIONS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_BATTLEGROUND_PLAYER_POSITIONS_DTO_PROXY()
    {
    }
}