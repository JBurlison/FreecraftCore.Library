using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_CHAT_NOT_IN_PARTY)]
[WireDataContractAttribute]
public sealed class SMSG_CHAT_NOT_IN_PARTY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_CHAT_NOT_IN_PARTY_DTO_PROXY()
    {
    }
}