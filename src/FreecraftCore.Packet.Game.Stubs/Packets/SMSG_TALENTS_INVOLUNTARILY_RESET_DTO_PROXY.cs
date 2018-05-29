using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_TALENTS_INVOLUNTARILY_RESET)]
[WireDataContractAttribute]
public sealed class SMSG_TALENTS_INVOLUNTARILY_RESET_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_TALENTS_INVOLUNTARILY_RESET_DTO_PROXY()
    {
    }
}