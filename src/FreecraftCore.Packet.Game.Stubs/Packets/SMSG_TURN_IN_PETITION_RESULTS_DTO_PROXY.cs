using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_TURN_IN_PETITION_RESULTS)]
[WireDataContractAttribute]
public sealed class SMSG_TURN_IN_PETITION_RESULTS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_TURN_IN_PETITION_RESULTS_DTO_PROXY()
    {
    }
}