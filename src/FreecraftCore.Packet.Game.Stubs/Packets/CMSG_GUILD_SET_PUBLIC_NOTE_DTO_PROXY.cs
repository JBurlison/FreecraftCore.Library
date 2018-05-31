using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_GUILD_SET_PUBLIC_NOTE)]
[WireDataContractAttribute]
public sealed class CMSG_GUILD_SET_PUBLIC_NOTE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_GUILD_SET_PUBLIC_NOTE_DTO_PROXY()
    {
    }
}