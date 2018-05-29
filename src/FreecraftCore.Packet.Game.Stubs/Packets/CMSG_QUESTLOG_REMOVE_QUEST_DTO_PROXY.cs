using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_QUESTLOG_REMOVE_QUEST)]
[WireDataContractAttribute]
public sealed class CMSG_QUESTLOG_REMOVE_QUEST_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_QUESTLOG_REMOVE_QUEST_DTO_PROXY()
    {
    }
}