using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_INSPECT_HONOR_STATS)]
[WireDataContractAttribute]
public sealed class MSG_INSPECT_HONOR_STATS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_INSPECT_HONOR_STATS_DTO_PROXY()
    {
    }
}