using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_PLAY_SPELL_IMPACT)]
[WireDataContractAttribute]
public sealed class SMSG_PLAY_SPELL_IMPACT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_PLAY_SPELL_IMPACT_DTO_PROXY()
    {
    }
}