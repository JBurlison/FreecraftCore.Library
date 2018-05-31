using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_UPDATE_LAST_INSTANCE)]
[WireDataContractAttribute]
public sealed class SMSG_UPDATE_LAST_INSTANCE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_UPDATE_LAST_INSTANCE_DTO_PROXY()
    {
    }
}