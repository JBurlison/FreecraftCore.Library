using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_CHAR_CUSTOMIZE)]
[WireDataContractAttribute]
public sealed class SMSG_CHAR_CUSTOMIZE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_CHAR_CUSTOMIZE_DTO_PROXY()
    {
    }
}