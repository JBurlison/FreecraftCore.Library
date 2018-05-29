using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_MAELSTROM_GM_SENT_MAIL)]
[WireDataContractAttribute]
public sealed class CMSG_MAELSTROM_GM_SENT_MAIL_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_MAELSTROM_GM_SENT_MAIL_DTO_PROXY()
    {
    }
}