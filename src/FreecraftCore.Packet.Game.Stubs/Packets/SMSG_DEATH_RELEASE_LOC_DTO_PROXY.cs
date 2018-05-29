using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_DEATH_RELEASE_LOC)]
[WireDataContractAttribute]
public sealed class SMSG_DEATH_RELEASE_LOC_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_DEATH_RELEASE_LOC_DTO_PROXY()
    {
    }
}