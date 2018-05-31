using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_QUESTGIVER_COMPLETE_QUEST)]
[WireDataContractAttribute]
public sealed class CMSG_QUESTGIVER_COMPLETE_QUEST_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_QUESTGIVER_COMPLETE_QUEST_DTO_PROXY()
    {
    }
}