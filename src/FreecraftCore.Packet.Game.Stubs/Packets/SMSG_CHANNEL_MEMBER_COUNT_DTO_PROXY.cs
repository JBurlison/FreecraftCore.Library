using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_CHANNEL_MEMBER_COUNT)]
[WireDataContractAttribute]
public sealed class SMSG_CHANNEL_MEMBER_COUNT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_CHANNEL_MEMBER_COUNT_DTO_PROXY()
    {
    }
}