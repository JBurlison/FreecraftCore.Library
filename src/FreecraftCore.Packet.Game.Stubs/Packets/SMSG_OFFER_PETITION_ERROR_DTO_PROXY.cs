using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_OFFER_PETITION_ERROR)]
[WireDataContractAttribute]
public sealed class SMSG_OFFER_PETITION_ERROR_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_OFFER_PETITION_ERROR_DTO_PROXY()
    {
    }
}