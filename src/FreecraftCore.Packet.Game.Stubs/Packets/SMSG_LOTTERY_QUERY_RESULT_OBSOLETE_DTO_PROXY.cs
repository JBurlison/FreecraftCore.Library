using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_LOTTERY_QUERY_RESULT_OBSOLETE)]
[WireDataContractAttribute]
public sealed class SMSG_LOTTERY_QUERY_RESULT_OBSOLETE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_LOTTERY_QUERY_RESULT_OBSOLETE_DTO_PROXY()
    {
    }
}