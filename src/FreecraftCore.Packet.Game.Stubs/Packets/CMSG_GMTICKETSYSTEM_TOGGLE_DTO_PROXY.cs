using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_GMTICKETSYSTEM_TOGGLE)]
[WireDataContractAttribute]
public sealed class CMSG_GMTICKETSYSTEM_TOGGLE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_GMTICKETSYSTEM_TOGGLE_DTO_PROXY()
    {
    }
}