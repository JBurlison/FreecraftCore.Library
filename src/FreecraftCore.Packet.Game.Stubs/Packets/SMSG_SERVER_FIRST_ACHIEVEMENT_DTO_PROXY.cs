using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_SERVER_FIRST_ACHIEVEMENT)]
[WireDataContractAttribute]
public sealed class SMSG_SERVER_FIRST_ACHIEVEMENT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_SERVER_FIRST_ACHIEVEMENT_DTO_PROXY()
    {
    }
}