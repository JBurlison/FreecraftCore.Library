using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_EXPECTED_SPAM_RECORDS)]
[WireDataContractAttribute]
public sealed class SMSG_EXPECTED_SPAM_RECORDS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_EXPECTED_SPAM_RECORDS_DTO_PROXY()
    {
    }
}