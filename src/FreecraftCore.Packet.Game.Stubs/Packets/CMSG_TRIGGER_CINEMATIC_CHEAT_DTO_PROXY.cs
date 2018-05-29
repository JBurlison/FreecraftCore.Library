using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_TRIGGER_CINEMATIC_CHEAT)]
[WireDataContractAttribute]
public sealed class CMSG_TRIGGER_CINEMATIC_CHEAT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_TRIGGER_CINEMATIC_CHEAT_DTO_PROXY()
    {
    }
}