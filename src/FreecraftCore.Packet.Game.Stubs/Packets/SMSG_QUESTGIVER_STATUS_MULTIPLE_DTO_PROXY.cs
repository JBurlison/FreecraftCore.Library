using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_QUESTGIVER_STATUS_MULTIPLE)]
[WireDataContractAttribute]
public sealed class SMSG_QUESTGIVER_STATUS_MULTIPLE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
{
    [ReadToEndAttribute]
    [WireMemberAttribute(1)]
    private byte[] _Data;
    public byte[] Data
    {
        get
        {
            return _Data;
        }

        set
        {
            _Data = value;
        }
    }

    public SMSG_QUESTGIVER_STATUS_MULTIPLE_DTO_PROXY()
    {
    }
}