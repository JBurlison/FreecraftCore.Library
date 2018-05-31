using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_PARTY_ASSIGNMENT)]
[WireDataContractAttribute]
public sealed class MSG_PARTY_ASSIGNMENT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_PARTY_ASSIGNMENT_DTO_PROXY()
    {
    }
}