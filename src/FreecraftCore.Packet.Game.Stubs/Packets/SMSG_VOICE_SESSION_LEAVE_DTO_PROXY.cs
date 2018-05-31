using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_VOICE_SESSION_LEAVE)]
[WireDataContractAttribute]
public sealed class SMSG_VOICE_SESSION_LEAVE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_VOICE_SESSION_LEAVE_DTO_PROXY()
    {
    }
}