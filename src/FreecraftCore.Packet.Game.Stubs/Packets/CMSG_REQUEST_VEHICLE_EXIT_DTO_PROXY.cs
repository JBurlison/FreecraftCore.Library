using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_REQUEST_VEHICLE_EXIT)]
[WireDataContractAttribute]
public sealed class CMSG_REQUEST_VEHICLE_EXIT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
{
    [ReadToEndAttribute]
    [WireMemberAttribute(1)]
    private byte[] _Data;
    public byte[] Data
    {
        get
        {
            return _Data;
        }

        set
        {
            _Data = value;
        }
    }

    public CMSG_REQUEST_VEHICLE_EXIT_DTO_PROXY()
    {
    }
}