using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_CHEAT_PLAYER_LOOKUP)]
[WireDataContractAttribute]
public sealed class SMSG_CHEAT_PLAYER_LOOKUP_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_CHEAT_PLAYER_LOOKUP_DTO_PROXY()
    {
    }
}