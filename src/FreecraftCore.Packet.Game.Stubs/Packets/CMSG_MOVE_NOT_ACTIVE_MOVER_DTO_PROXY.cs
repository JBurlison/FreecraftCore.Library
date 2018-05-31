using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_MOVE_NOT_ACTIVE_MOVER)]
[WireDataContractAttribute]
public sealed class CMSG_MOVE_NOT_ACTIVE_MOVER_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_MOVE_NOT_ACTIVE_MOVER_DTO_PROXY()
    {
    }
}