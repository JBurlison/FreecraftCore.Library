using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_AUTOEQUIP_GROUND_ITEM)]
[WireDataContractAttribute]
public sealed class CMSG_AUTOEQUIP_GROUND_ITEM_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_AUTOEQUIP_GROUND_ITEM_DTO_PROXY()
    {
    }
}