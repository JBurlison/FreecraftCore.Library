using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_FEIGN_DEATH_RESISTED)]
[WireDataContractAttribute]
public sealed class SMSG_FEIGN_DEATH_RESISTED_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_FEIGN_DEATH_RESISTED_DTO_PROXY()
    {
    }
}