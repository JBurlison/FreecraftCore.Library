using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_FEATURE_SYSTEM_STATUS)]
[WireDataContractAttribute]
public sealed class SMSG_FEATURE_SYSTEM_STATUS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_FEATURE_SYSTEM_STATUS_DTO_PROXY()
    {
    }
}