using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_EQUIPMENT_SET_USE)]
[WireDataContractAttribute]
public sealed class CMSG_EQUIPMENT_SET_USE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_EQUIPMENT_SET_USE_DTO_PROXY()
    {
    }
}