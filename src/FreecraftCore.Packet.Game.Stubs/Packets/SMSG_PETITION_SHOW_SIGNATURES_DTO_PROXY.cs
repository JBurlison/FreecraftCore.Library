using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_PETITION_SHOW_SIGNATURES)]
[WireDataContractAttribute]
public sealed class SMSG_PETITION_SHOW_SIGNATURES_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_PETITION_SHOW_SIGNATURES_DTO_PROXY()
    {
    }
}