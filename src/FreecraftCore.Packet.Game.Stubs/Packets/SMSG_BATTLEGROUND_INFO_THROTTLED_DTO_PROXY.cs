using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_BATTLEGROUND_INFO_THROTTLED)]
[WireDataContractAttribute]
public sealed class SMSG_BATTLEGROUND_INFO_THROTTLED_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_BATTLEGROUND_INFO_THROTTLED_DTO_PROXY()
    {
    }
}