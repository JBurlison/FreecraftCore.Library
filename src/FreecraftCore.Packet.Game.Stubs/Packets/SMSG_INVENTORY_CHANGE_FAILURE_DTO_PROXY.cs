using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_INVENTORY_CHANGE_FAILURE)]
[WireDataContractAttribute]
public sealed class SMSG_INVENTORY_CHANGE_FAILURE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_INVENTORY_CHANGE_FAILURE_DTO_PROXY()
    {
    }
}