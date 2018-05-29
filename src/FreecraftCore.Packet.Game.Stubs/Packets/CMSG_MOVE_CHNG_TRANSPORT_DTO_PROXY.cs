using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_MOVE_CHNG_TRANSPORT)]
[WireDataContractAttribute]
public sealed class CMSG_MOVE_CHNG_TRANSPORT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_MOVE_CHNG_TRANSPORT_DTO_PROXY()
    {
    }
}