using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_LFG_OFFER_CONTINUE)]
[WireDataContractAttribute]
public sealed class SMSG_LFG_OFFER_CONTINUE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_LFG_OFFER_CONTINUE_DTO_PROXY()
    {
    }
}