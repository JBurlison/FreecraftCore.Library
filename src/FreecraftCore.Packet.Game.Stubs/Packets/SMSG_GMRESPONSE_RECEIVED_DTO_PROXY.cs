using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_GMRESPONSE_RECEIVED)]
[WireDataContractAttribute]
public sealed class SMSG_GMRESPONSE_RECEIVED_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_GMRESPONSE_RECEIVED_DTO_PROXY()
    {
    }
}