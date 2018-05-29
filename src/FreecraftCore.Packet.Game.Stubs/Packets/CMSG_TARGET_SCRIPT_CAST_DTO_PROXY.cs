using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_TARGET_SCRIPT_CAST)]
[WireDataContractAttribute]
public sealed class CMSG_TARGET_SCRIPT_CAST_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_TARGET_SCRIPT_CAST_DTO_PROXY()
    {
    }
}