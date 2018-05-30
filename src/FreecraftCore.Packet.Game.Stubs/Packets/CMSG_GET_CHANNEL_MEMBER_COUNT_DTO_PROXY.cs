using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_GET_CHANNEL_MEMBER_COUNT)]
[WireDataContractAttribute]
public sealed class CMSG_GET_CHANNEL_MEMBER_COUNT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_GET_CHANNEL_MEMBER_COUNT_DTO_PROXY()
    {
    }
}