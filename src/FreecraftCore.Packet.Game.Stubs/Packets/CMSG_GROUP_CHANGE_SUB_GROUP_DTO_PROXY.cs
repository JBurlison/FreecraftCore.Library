using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_GROUP_CHANGE_SUB_GROUP)]
[WireDataContractAttribute]
public sealed class CMSG_GROUP_CHANGE_SUB_GROUP_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_GROUP_CHANGE_SUB_GROUP_DTO_PROXY()
    {
    }
}