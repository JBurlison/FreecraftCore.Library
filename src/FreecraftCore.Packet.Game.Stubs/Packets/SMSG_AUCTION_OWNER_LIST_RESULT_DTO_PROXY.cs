using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_AUCTION_OWNER_LIST_RESULT)]
[WireDataContractAttribute]
public sealed class SMSG_AUCTION_OWNER_LIST_RESULT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_AUCTION_OWNER_LIST_RESULT_DTO_PROXY()
    {
    }
}