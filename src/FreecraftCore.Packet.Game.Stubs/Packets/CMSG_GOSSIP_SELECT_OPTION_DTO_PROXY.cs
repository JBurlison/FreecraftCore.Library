using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_GOSSIP_SELECT_OPTION)]
[WireDataContractAttribute]
public sealed class CMSG_GOSSIP_SELECT_OPTION_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_GOSSIP_SELECT_OPTION_DTO_PROXY()
    {
    }
}