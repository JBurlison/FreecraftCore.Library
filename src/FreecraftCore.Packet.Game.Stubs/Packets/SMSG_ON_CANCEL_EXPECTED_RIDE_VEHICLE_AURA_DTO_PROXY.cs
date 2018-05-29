using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_ON_CANCEL_EXPECTED_RIDE_VEHICLE_AURA)]
[WireDataContractAttribute]
public sealed class SMSG_ON_CANCEL_EXPECTED_RIDE_VEHICLE_AURA_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_ON_CANCEL_EXPECTED_RIDE_VEHICLE_AURA_DTO_PROXY()
    {
    }
}