using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_FORCE_MOVE_ROOT)]
[WireDataContractAttribute]
public sealed class SMSG_FORCE_MOVE_ROOT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_FORCE_MOVE_ROOT_DTO_PROXY()
    {
    }
}