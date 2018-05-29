using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_ECHO_PARTY_SQUELCH)]
[WireDataContractAttribute]
public sealed class SMSG_ECHO_PARTY_SQUELCH_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_ECHO_PARTY_SQUELCH_DTO_PROXY()
    {
    }
}