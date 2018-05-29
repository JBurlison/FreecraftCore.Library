using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_COMSAT_RECONNECT_TRY)]
[WireDataContractAttribute]
public sealed class SMSG_COMSAT_RECONNECT_TRY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_COMSAT_RECONNECT_TRY_DTO_PROXY()
    {
    }
}