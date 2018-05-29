using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_IGNORE_REQUIREMENTS_CHEAT)]
[WireDataContractAttribute]
public sealed class SMSG_IGNORE_REQUIREMENTS_CHEAT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_IGNORE_REQUIREMENTS_CHEAT_DTO_PROXY()
    {
    }
}