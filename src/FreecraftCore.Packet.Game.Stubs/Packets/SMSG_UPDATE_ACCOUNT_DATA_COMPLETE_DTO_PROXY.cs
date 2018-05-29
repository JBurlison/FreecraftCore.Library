using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_UPDATE_ACCOUNT_DATA_COMPLETE)]
[WireDataContractAttribute]
public sealed class SMSG_UPDATE_ACCOUNT_DATA_COMPLETE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_UPDATE_ACCOUNT_DATA_COMPLETE_DTO_PROXY()
    {
    }
}