using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CHANNEL_SILENCE_VOICE)]
[WireDataContractAttribute]
public sealed class CMSG_CHANNEL_SILENCE_VOICE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CHANNEL_SILENCE_VOICE_DTO_PROXY()
    {
    }
}