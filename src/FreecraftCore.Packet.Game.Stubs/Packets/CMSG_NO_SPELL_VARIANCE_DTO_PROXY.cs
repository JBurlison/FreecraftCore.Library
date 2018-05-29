using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_NO_SPELL_VARIANCE)]
[WireDataContractAttribute]
public sealed class CMSG_NO_SPELL_VARIANCE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_NO_SPELL_VARIANCE_DTO_PROXY()
    {
    }
}