using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_SET_ALLOW_LOW_LEVEL_RAID2)]
[WireDataContractAttribute]
public sealed class CMSG_SET_ALLOW_LOW_LEVEL_RAID2_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_SET_ALLOW_LOW_LEVEL_RAID2_DTO_PROXY()
    {
    }
}