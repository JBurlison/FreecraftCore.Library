using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_TEST_DROP_RATE_RESULT)]
[WireDataContractAttribute]
public sealed class SMSG_TEST_DROP_RATE_RESULT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_TEST_DROP_RATE_RESULT_DTO_PROXY()
    {
    }
}