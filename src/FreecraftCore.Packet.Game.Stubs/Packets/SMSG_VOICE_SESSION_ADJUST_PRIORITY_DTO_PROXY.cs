using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_VOICE_SESSION_ADJUST_PRIORITY)]
[WireDataContractAttribute]
public sealed class SMSG_VOICE_SESSION_ADJUST_PRIORITY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_VOICE_SESSION_ADJUST_PRIORITY_DTO_PROXY()
    {
    }
}