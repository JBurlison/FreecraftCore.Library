using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CANCEL_TEMP_ENCHANTMENT)]
[WireDataContractAttribute]
public sealed class CMSG_CANCEL_TEMP_ENCHANTMENT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
{
    [ReadToEndAttribute]
    [WireMemberAttribute(1)]
    private byte[] _Data;
    public byte[] Data
    {
        get
        {
            return _Data;
        }

        set
        {
            _Data = value;
        }
    }

    public CMSG_CANCEL_TEMP_ENCHANTMENT_DTO_PROXY()
    {
    }
}