using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CANCEL_AUTO_REPEAT_SPELL)]
[WireDataContractAttribute]
public sealed class CMSG_CANCEL_AUTO_REPEAT_SPELL_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CANCEL_AUTO_REPEAT_SPELL_DTO_PROXY()
    {
    }
}