using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_RESPOND_INSPECT_ACHIEVEMENTS)]
[WireDataContractAttribute]
public sealed class SMSG_RESPOND_INSPECT_ACHIEVEMENTS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_RESPOND_INSPECT_ACHIEVEMENTS_DTO_PROXY()
    {
    }
}