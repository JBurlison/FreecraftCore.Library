using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_RESET_RANGED_COMBAT_TIMER)]
[WireDataContractAttribute]
public sealed class SMSG_RESET_RANGED_COMBAT_TIMER_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_RESET_RANGED_COMBAT_TIMER_DTO_PROXY()
    {
    }
}