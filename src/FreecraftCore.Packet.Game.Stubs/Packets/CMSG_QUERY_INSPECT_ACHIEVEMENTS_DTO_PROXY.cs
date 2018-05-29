using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_QUERY_INSPECT_ACHIEVEMENTS)]
[WireDataContractAttribute]
public sealed class CMSG_QUERY_INSPECT_ACHIEVEMENTS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_QUERY_INSPECT_ACHIEVEMENTS_DTO_PROXY()
    {
    }
}