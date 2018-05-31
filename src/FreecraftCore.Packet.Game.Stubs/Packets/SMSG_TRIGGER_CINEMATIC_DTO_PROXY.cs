using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_TRIGGER_CINEMATIC)]
[WireDataContractAttribute]
public sealed class SMSG_TRIGGER_CINEMATIC_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_TRIGGER_CINEMATIC_DTO_PROXY()
    {
    }
}