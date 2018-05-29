using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_GROUPACTION_THROTTLED)]
[WireDataContractAttribute]
public sealed class SMSG_GROUPACTION_THROTTLED_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_GROUPACTION_THROTTLED_DTO_PROXY()
    {
    }
}