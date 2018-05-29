using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_DUEL_OUTOFBOUNDS)]
[WireDataContractAttribute]
public sealed class SMSG_DUEL_OUTOFBOUNDS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_DUEL_OUTOFBOUNDS_DTO_PROXY()
    {
    }
}