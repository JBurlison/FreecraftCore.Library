using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.UMSG_DELETE_GUILD_CHARTER)]
[WireDataContractAttribute]
public sealed class UMSG_DELETE_GUILD_CHARTER_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public UMSG_DELETE_GUILD_CHARTER_DTO_PROXY()
    {
    }
}