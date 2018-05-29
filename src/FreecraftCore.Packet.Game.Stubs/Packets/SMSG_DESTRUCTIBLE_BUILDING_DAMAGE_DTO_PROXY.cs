using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_DESTRUCTIBLE_BUILDING_DAMAGE)]
[WireDataContractAttribute]
public sealed class SMSG_DESTRUCTIBLE_BUILDING_DAMAGE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_DESTRUCTIBLE_BUILDING_DAMAGE_DTO_PROXY()
    {
    }
}