using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_UPDATE_MISSILE_TRAJECTORY)]
[WireDataContractAttribute]
public sealed class CMSG_UPDATE_MISSILE_TRAJECTORY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_UPDATE_MISSILE_TRAJECTORY_DTO_PROXY()
    {
    }
}