using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_LOOT_MONEY_NOTIFY)]
[WireDataContractAttribute]
public sealed class SMSG_LOOT_MONEY_NOTIFY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_LOOT_MONEY_NOTIFY_DTO_PROXY()
    {
    }
}