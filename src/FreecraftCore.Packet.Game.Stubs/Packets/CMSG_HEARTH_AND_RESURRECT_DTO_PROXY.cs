using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_HEARTH_AND_RESURRECT)]
[WireDataContractAttribute]
public sealed class CMSG_HEARTH_AND_RESURRECT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_HEARTH_AND_RESURRECT_DTO_PROXY()
    {
    }
}