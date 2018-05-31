using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_INVALID_PROMOTION_CODE)]
[WireDataContractAttribute]
public sealed class SMSG_INVALID_PROMOTION_CODE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_INVALID_PROMOTION_CODE_DTO_PROXY()
    {
    }
}