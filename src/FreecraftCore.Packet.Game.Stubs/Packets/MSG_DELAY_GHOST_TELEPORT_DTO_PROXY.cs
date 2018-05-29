using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_DELAY_GHOST_TELEPORT)]
[WireDataContractAttribute]
public sealed class MSG_DELAY_GHOST_TELEPORT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_DELAY_GHOST_TELEPORT_DTO_PROXY()
    {
    }
}