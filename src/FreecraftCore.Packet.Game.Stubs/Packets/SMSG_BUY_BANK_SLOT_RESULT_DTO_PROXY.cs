using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_BUY_BANK_SLOT_RESULT)]
[WireDataContractAttribute]
public sealed class SMSG_BUY_BANK_SLOT_RESULT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_BUY_BANK_SLOT_RESULT_DTO_PROXY()
    {
    }
}