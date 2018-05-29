using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_COMMENTATOR_GET_PLAYER_INFO)]
[WireDataContractAttribute]
public sealed class CMSG_COMMENTATOR_GET_PLAYER_INFO_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_COMMENTATOR_GET_PLAYER_INFO_DTO_PROXY()
    {
    }
}