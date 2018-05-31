using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_SPIRIT_HEALER_CONFIRM)]
[WireDataContractAttribute]
public sealed class SMSG_SPIRIT_HEALER_CONFIRM_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_SPIRIT_HEALER_CONFIRM_DTO_PROXY()
    {
    }
}