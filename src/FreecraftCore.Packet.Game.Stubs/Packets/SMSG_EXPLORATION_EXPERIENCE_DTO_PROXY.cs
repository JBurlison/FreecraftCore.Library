using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_EXPLORATION_EXPERIENCE)]
[WireDataContractAttribute]
public sealed class SMSG_EXPLORATION_EXPERIENCE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_EXPLORATION_EXPERIENCE_DTO_PROXY()
    {
    }
}