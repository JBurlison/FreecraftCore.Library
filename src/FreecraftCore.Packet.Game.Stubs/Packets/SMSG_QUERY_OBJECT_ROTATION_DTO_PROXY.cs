using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_QUERY_OBJECT_ROTATION)]
[WireDataContractAttribute]
public sealed class SMSG_QUERY_OBJECT_ROTATION_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_QUERY_OBJECT_ROTATION_DTO_PROXY()
    {
    }
}