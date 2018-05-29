using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_ACTIVE_PVP_CHEAT)]
[WireDataContractAttribute]
public sealed class CMSG_ACTIVE_PVP_CHEAT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_ACTIVE_PVP_CHEAT_DTO_PROXY()
    {
    }
}