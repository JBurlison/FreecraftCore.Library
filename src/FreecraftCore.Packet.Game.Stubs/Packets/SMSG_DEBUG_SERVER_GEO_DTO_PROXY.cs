using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_DEBUG_SERVER_GEO)]
[WireDataContractAttribute]
public sealed class SMSG_DEBUG_SERVER_GEO_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_DEBUG_SERVER_GEO_DTO_PROXY()
    {
    }
}