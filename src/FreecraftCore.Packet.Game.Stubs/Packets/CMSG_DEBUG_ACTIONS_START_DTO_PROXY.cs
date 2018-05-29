using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_DEBUG_ACTIONS_START)]
[WireDataContractAttribute]
public sealed class CMSG_DEBUG_ACTIONS_START_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_DEBUG_ACTIONS_START_DTO_PROXY()
    {
    }
}