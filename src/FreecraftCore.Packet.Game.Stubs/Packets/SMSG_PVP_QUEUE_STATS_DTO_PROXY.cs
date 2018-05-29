using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_PVP_QUEUE_STATS)]
[WireDataContractAttribute]
public sealed class SMSG_PVP_QUEUE_STATS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_PVP_QUEUE_STATS_DTO_PROXY()
    {
    }
}