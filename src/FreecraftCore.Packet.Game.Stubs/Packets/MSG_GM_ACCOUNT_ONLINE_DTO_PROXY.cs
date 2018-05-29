using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_GM_ACCOUNT_ONLINE)]
[WireDataContractAttribute]
public sealed class MSG_GM_ACCOUNT_ONLINE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_GM_ACCOUNT_ONLINE_DTO_PROXY()
    {
    }
}