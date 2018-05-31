using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_DURABILITY_DAMAGE_DEATH)]
[WireDataContractAttribute]
public sealed class SMSG_DURABILITY_DAMAGE_DEATH_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_DURABILITY_DAMAGE_DEATH_DTO_PROXY()
    {
    }
}