using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_DEL_PVP_MEDAL_CHEAT)]
[WireDataContractAttribute]
public sealed class CMSG_DEL_PVP_MEDAL_CHEAT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_DEL_PVP_MEDAL_CHEAT_DTO_PROXY()
    {
    }
}