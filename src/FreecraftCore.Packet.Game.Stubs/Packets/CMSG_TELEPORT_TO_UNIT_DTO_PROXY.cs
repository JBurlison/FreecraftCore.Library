using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_TELEPORT_TO_UNIT)]
[WireDataContractAttribute]
public sealed class CMSG_TELEPORT_TO_UNIT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_TELEPORT_TO_UNIT_DTO_PROXY()
    {
    }
}