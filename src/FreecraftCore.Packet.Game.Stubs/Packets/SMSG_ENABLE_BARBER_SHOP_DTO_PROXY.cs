using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_ENABLE_BARBER_SHOP)]
[WireDataContractAttribute]
public sealed class SMSG_ENABLE_BARBER_SHOP_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_ENABLE_BARBER_SHOP_DTO_PROXY()
    {
    }
}