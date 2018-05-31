using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_SET_FLAT_SPELL_MODIFIER)]
[WireDataContractAttribute]
public sealed class SMSG_SET_FLAT_SPELL_MODIFIER_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_SET_FLAT_SPELL_MODIFIER_DTO_PROXY()
    {
    }
}