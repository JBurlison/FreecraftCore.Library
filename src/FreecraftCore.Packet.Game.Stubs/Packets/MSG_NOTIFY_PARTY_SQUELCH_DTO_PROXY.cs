using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_NOTIFY_PARTY_SQUELCH)]
[WireDataContractAttribute]
public sealed class MSG_NOTIFY_PARTY_SQUELCH_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_NOTIFY_PARTY_SQUELCH_DTO_PROXY()
    {
    }
}