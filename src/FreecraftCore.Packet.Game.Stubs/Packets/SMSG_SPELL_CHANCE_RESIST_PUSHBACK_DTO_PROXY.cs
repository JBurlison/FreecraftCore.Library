using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_SPELL_CHANCE_RESIST_PUSHBACK)]
[WireDataContractAttribute]
public sealed class SMSG_SPELL_CHANCE_RESIST_PUSHBACK_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_SPELL_CHANCE_RESIST_PUSHBACK_DTO_PROXY()
    {
    }
}