using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_QUEST_FORCE_REMOVE)]
[WireDataContractAttribute]
public sealed class SMSG_QUEST_FORCE_REMOVE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_QUEST_FORCE_REMOVE_DTO_PROXY()
    {
    }
}