using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_PARTY_MEMBER_STATS_FULL)]
[WireDataContractAttribute]
public sealed class SMSG_PARTY_MEMBER_STATS_FULL_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_PARTY_MEMBER_STATS_FULL_DTO_PROXY()
    {
    }
}