using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_PERFORM_ACTION_SET)]
[WireDataContractAttribute]
public sealed class CMSG_PERFORM_ACTION_SET_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_PERFORM_ACTION_SET_DTO_PROXY()
    {
    }
}