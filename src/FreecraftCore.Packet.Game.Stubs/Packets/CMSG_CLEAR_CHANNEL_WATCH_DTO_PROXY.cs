using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CLEAR_CHANNEL_WATCH)]
[WireDataContractAttribute]
public sealed class CMSG_CLEAR_CHANNEL_WATCH_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CLEAR_CHANNEL_WATCH_DTO_PROXY()
    {
    }
}