using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_BATTLEFIELD_MANAGER_ADVANCE_STATE)]
[WireDataContractAttribute]
public sealed class CMSG_BATTLEFIELD_MANAGER_ADVANCE_STATE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_BATTLEFIELD_MANAGER_ADVANCE_STATE_DTO_PROXY()
    {
    }
}