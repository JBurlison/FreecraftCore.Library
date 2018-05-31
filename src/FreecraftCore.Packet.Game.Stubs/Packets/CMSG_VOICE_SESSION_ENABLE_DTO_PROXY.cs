using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_VOICE_SESSION_ENABLE)]
[WireDataContractAttribute]
public sealed class CMSG_VOICE_SESSION_ENABLE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_VOICE_SESSION_ENABLE_DTO_PROXY()
    {
    }
}