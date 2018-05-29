using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_VOICE_CHAT_STATUS)]
[WireDataContractAttribute]
public sealed class SMSG_VOICE_CHAT_STATUS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_VOICE_CHAT_STATUS_DTO_PROXY()
    {
    }
}