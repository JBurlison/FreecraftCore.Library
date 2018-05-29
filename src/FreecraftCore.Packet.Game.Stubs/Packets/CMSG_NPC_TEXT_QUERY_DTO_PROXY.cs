using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_NPC_TEXT_QUERY)]
[WireDataContractAttribute]
public sealed class CMSG_NPC_TEXT_QUERY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_NPC_TEXT_QUERY_DTO_PROXY()
    {
    }
}