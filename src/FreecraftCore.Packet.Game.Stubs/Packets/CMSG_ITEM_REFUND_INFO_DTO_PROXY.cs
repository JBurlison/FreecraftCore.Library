using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_ITEM_REFUND_INFO)]
[WireDataContractAttribute]
public sealed class CMSG_ITEM_REFUND_INFO_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_ITEM_REFUND_INFO_DTO_PROXY()
    {
    }
}