using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_COMPRESSED_UPDATE_OBJECT)]
[WireDataContractAttribute]
public sealed class SMSG_COMPRESSED_UPDATE_OBJECT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_COMPRESSED_UPDATE_OBJECT_DTO_PROXY()
    {
    }
}