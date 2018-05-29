using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_TABARDVENDOR_ACTIVATE)]
[WireDataContractAttribute]
public sealed class MSG_TABARDVENDOR_ACTIVATE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_TABARDVENDOR_ACTIVATE_DTO_PROXY()
    {
    }
}