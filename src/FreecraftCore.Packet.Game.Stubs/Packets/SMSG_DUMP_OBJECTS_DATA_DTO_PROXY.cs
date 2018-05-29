using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_DUMP_OBJECTS_DATA)]
[WireDataContractAttribute]
public sealed class SMSG_DUMP_OBJECTS_DATA_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_DUMP_OBJECTS_DATA_DTO_PROXY()
    {
    }
}