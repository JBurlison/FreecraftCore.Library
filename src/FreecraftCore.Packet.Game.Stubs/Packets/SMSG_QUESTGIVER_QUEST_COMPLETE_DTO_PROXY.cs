using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_QUESTGIVER_QUEST_COMPLETE)]
[WireDataContractAttribute]
public sealed class SMSG_QUESTGIVER_QUEST_COMPLETE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_QUESTGIVER_QUEST_COMPLETE_DTO_PROXY()
    {
    }
}