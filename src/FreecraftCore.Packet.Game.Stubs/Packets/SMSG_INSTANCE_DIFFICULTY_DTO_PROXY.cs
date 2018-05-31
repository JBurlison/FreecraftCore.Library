using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_INSTANCE_DIFFICULTY)]
[WireDataContractAttribute]
public sealed class SMSG_INSTANCE_DIFFICULTY_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_INSTANCE_DIFFICULTY_DTO_PROXY()
    {
    }
}