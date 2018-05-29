using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_PROPOSE_LEVEL_GRANT)]
[WireDataContractAttribute]
public sealed class SMSG_PROPOSE_LEVEL_GRANT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_PROPOSE_LEVEL_GRANT_DTO_PROXY()
    {
    }
}