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
            return Data;
        }

        set
        {
            Data = value;
        }
    }

    public MSG_PARTY_ASSIGNMENT_DTO_PROXY()
    {
    }
}