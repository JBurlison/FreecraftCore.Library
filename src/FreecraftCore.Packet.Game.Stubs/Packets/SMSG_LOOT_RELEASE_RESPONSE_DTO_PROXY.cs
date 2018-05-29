using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_LOOT_RELEASE_RESPONSE)]
[WireDataContractAttribute]
public sealed class SMSG_LOOT_RELEASE_RESPONSE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_LOOT_RELEASE_RESPONSE_DTO_PROXY()
    {
    }
}