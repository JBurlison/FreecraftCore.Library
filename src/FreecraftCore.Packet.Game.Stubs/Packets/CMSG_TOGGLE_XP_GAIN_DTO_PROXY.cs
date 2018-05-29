using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_TOGGLE_XP_GAIN)]
[WireDataContractAttribute]
public sealed class CMSG_TOGGLE_XP_GAIN_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_TOGGLE_XP_GAIN_DTO_PROXY()
    {
    }
}