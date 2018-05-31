using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_QUEST_CONFIRM_ACCEPT)]
[WireDataContractAttribute]
public sealed class CMSG_QUEST_CONFIRM_ACCEPT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_QUEST_CONFIRM_ACCEPT_DTO_PROXY()
    {
    }
}