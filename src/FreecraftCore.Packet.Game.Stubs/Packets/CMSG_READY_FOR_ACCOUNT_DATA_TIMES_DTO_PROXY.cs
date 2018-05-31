using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_READY_FOR_ACCOUNT_DATA_TIMES)]
[WireDataContractAttribute]
public sealed class CMSG_READY_FOR_ACCOUNT_DATA_TIMES_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_READY_FOR_ACCOUNT_DATA_TIMES_DTO_PROXY()
    {
    }
}