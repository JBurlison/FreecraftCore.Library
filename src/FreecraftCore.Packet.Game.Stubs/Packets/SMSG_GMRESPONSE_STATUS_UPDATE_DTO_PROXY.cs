using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_GMRESPONSE_STATUS_UPDATE)]
[WireDataContractAttribute]
public sealed class SMSG_GMRESPONSE_STATUS_UPDATE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_GMRESPONSE_STATUS_UPDATE_DTO_PROXY()
    {
    }
}