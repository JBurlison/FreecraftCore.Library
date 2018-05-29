using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_BUY_LOTTERY_TICKET_OBSOLETE)]
[WireDataContractAttribute]
public sealed class CMSG_BUY_LOTTERY_TICKET_OBSOLETE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_BUY_LOTTERY_TICKET_OBSOLETE_DTO_PROXY()
    {
    }
}