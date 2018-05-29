using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_SET_DUNGEON_DIFFICULTY)]
[WireDataContractAttribute]
public sealed class MSG_SET_DUNGEON_DIFFICULTY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_SET_DUNGEON_DIFFICULTY_DTO_PROXY()
    {
    }
}