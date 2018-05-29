using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_SET_TITLE_SUFFIX)]
[WireDataContractAttribute]
public sealed class CMSG_SET_TITLE_SUFFIX_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_SET_TITLE_SUFFIX_DTO_PROXY()
    {
    }
}