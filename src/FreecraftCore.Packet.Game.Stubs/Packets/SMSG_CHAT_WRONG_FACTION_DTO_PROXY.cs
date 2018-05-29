using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_CHAT_WRONG_FACTION)]
[WireDataContractAttribute]
public sealed class SMSG_CHAT_WRONG_FACTION_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_CHAT_WRONG_FACTION_DTO_PROXY()
    {
    }
}