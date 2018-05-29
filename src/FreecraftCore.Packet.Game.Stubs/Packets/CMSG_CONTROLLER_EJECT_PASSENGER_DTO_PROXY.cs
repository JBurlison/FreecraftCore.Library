using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CONTROLLER_EJECT_PASSENGER)]
[WireDataContractAttribute]
public sealed class CMSG_CONTROLLER_EJECT_PASSENGER_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CONTROLLER_EJECT_PASSENGER_DTO_PROXY()
    {
    }
}