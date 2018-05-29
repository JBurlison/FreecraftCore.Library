using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_ATTACKSWING_CANT_ATTACK)]
[WireDataContractAttribute]
public sealed class SMSG_ATTACKSWING_CANT_ATTACK_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_ATTACKSWING_CANT_ATTACK_DTO_PROXY()
    {
    }
}