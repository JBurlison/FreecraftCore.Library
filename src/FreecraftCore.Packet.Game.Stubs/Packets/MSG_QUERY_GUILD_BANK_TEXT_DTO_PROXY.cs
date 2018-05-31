using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_QUERY_GUILD_BANK_TEXT)]
[WireDataContractAttribute]
public sealed class MSG_QUERY_GUILD_BANK_TEXT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_QUERY_GUILD_BANK_TEXT_DTO_PROXY()
    {
    }
}