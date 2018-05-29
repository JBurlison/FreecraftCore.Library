using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_COMMENTATOR_PLAYER_INFO)]
[WireDataContractAttribute]
public sealed class SMSG_COMMENTATOR_PLAYER_INFO_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_COMMENTATOR_PLAYER_INFO_DTO_PROXY()
    {
    }
}