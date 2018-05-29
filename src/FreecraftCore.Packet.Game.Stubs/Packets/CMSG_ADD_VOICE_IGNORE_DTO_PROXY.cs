using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_ADD_VOICE_IGNORE)]
[WireDataContractAttribute]
public sealed class CMSG_ADD_VOICE_IGNORE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_ADD_VOICE_IGNORE_DTO_PROXY()
    {
    }
}