using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_COMMENTATOR_SKIRMISH_QUEUE_RESULT1)]
[WireDataContractAttribute]
public sealed class SMSG_COMMENTATOR_SKIRMISH_QUEUE_RESULT1_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_COMMENTATOR_SKIRMISH_QUEUE_RESULT1_DTO_PROXY()
    {
    }
}