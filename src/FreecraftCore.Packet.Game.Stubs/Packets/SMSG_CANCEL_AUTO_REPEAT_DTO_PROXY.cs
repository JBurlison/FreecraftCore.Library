using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_CANCEL_AUTO_REPEAT)]
[WireDataContractAttribute]
public sealed class SMSG_CANCEL_AUTO_REPEAT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_CANCEL_AUTO_REPEAT_DTO_PROXY()
    {
    }
}