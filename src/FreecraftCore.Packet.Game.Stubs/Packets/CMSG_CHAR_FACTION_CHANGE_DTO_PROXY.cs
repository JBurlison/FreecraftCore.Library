using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CHAR_FACTION_CHANGE)]
[WireDataContractAttribute]
public sealed class CMSG_CHAR_FACTION_CHANGE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CHAR_FACTION_CHANGE_DTO_PROXY()
    {
    }
}