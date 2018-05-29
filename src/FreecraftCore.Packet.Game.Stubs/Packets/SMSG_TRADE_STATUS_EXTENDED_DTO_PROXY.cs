using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_TRADE_STATUS_EXTENDED)]
[WireDataContractAttribute]
public sealed class SMSG_TRADE_STATUS_EXTENDED_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_TRADE_STATUS_EXTENDED_DTO_PROXY()
    {
    }
}