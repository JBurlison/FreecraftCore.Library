using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_COMPLETE_ACHIEVEMENT_CHEAT)]
[WireDataContractAttribute]
public sealed class CMSG_COMPLETE_ACHIEVEMENT_CHEAT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_COMPLETE_ACHIEVEMENT_CHEAT_DTO_PROXY()
    {
    }
}