using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_FLAG_QUEST_FINISH)]
[WireDataContractAttribute]
public sealed class CMSG_FLAG_QUEST_FINISH_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_FLAG_QUEST_FINISH_DTO_PROXY()
    {
    }
}