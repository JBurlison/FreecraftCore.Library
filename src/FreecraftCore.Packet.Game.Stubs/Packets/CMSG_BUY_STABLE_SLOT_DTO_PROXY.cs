using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_BUY_STABLE_SLOT)]
[WireDataContractAttribute]
public sealed class CMSG_BUY_STABLE_SLOT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_BUY_STABLE_SLOT_DTO_PROXY()
    {
    }
}