using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK)]
[WireDataContractAttribute]
public sealed class CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK_DTO_PROXY()
    {
    }
}