using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_SOCKET_GEMS_RESULT)]
[WireDataContractAttribute]
public sealed class SMSG_SOCKET_GEMS_RESULT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_SOCKET_GEMS_RESULT_DTO_PROXY()
    {
    }
}