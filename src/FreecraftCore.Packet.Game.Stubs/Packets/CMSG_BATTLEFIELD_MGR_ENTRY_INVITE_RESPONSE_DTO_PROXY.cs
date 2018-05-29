using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_BATTLEFIELD_MGR_ENTRY_INVITE_RESPONSE)]
[WireDataContractAttribute]
public sealed class CMSG_BATTLEFIELD_MGR_ENTRY_INVITE_RESPONSE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_BATTLEFIELD_MGR_ENTRY_INVITE_RESPONSE_DTO_PROXY()
    {
    }
}