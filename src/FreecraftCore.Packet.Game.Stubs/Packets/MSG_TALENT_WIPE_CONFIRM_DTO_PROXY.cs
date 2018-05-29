using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_TALENT_WIPE_CONFIRM)]
[WireDataContractAttribute]
public sealed class MSG_TALENT_WIPE_CONFIRM_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_TALENT_WIPE_CONFIRM_DTO_PROXY()
    {
    }
}