using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_LOGIN_VERIFY_WORLD)]
[WireDataContractAttribute]
public sealed class SMSG_LOGIN_VERIFY_WORLD_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_LOGIN_VERIFY_WORLD_DTO_PROXY()
    {
    }
}