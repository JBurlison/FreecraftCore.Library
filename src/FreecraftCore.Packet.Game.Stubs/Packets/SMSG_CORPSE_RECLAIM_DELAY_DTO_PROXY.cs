using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_CORPSE_RECLAIM_DELAY)]
[WireDataContractAttribute]
public sealed class SMSG_CORPSE_RECLAIM_DELAY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_CORPSE_RECLAIM_DELAY_DTO_PROXY()
    {
    }
}