using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_SPELLORDAMAGE_IMMUNE)]
[WireDataContractAttribute]
public sealed class SMSG_SPELLORDAMAGE_IMMUNE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_SPELLORDAMAGE_IMMUNE_DTO_PROXY()
    {
    }
}