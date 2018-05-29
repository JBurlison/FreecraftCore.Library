using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_DEV_SHOWLABEL)]
[WireDataContractAttribute]
public sealed class MSG_DEV_SHOWLABEL_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_DEV_SHOWLABEL_DTO_PROXY()
    {
    }
}