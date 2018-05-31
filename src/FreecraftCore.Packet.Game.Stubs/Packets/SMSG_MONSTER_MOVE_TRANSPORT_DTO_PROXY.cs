using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_MONSTER_MOVE_TRANSPORT)]
[WireDataContractAttribute]
public sealed class SMSG_MONSTER_MOVE_TRANSPORT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_MONSTER_MOVE_TRANSPORT_DTO_PROXY()
    {
    }
}