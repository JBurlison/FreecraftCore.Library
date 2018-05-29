using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_CLIENT_CONTROL_UPDATE)]
[WireDataContractAttribute]
public sealed class SMSG_CLIENT_CONTROL_UPDATE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_CLIENT_CONTROL_UPDATE_DTO_PROXY()
    {
    }
}