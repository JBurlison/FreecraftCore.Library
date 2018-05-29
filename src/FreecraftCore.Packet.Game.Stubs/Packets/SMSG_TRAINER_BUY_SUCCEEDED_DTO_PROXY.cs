using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_TRAINER_BUY_SUCCEEDED)]
[WireDataContractAttribute]
public sealed class SMSG_TRAINER_BUY_SUCCEEDED_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_TRAINER_BUY_SUCCEEDED_DTO_PROXY()
    {
    }
}