using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_GM_SET_CRITERIA_FOR_PLAYER)]
[WireDataContractAttribute]
public sealed class CMSG_GM_SET_CRITERIA_FOR_PLAYER_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_GM_SET_CRITERIA_FOR_PLAYER_DTO_PROXY()
    {
    }
}