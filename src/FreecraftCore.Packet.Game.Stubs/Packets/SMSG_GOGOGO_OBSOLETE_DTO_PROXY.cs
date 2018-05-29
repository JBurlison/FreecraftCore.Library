using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_GOGOGO_OBSOLETE)]
[WireDataContractAttribute]
public sealed class SMSG_GOGOGO_OBSOLETE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_GOGOGO_OBSOLETE_DTO_PROXY()
    {
    }
}