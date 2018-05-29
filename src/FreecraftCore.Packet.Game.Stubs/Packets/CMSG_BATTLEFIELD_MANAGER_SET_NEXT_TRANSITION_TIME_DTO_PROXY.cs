using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_BATTLEFIELD_MANAGER_SET_NEXT_TRANSITION_TIME)]
[WireDataContractAttribute]
public sealed class CMSG_BATTLEFIELD_MANAGER_SET_NEXT_TRANSITION_TIME_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_BATTLEFIELD_MANAGER_SET_NEXT_TRANSITION_TIME_DTO_PROXY()
    {
    }
}