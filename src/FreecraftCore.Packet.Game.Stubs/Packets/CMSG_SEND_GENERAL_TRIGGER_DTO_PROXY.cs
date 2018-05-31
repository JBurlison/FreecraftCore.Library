using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_SEND_GENERAL_TRIGGER)]
[WireDataContractAttribute]
public sealed class CMSG_SEND_GENERAL_TRIGGER_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_SEND_GENERAL_TRIGGER_DTO_PROXY()
    {
    }
}