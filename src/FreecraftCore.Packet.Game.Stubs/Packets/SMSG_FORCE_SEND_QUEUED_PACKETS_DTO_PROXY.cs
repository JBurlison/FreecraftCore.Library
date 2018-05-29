using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_FORCE_SEND_QUEUED_PACKETS)]
[WireDataContractAttribute]
public sealed class SMSG_FORCE_SEND_QUEUED_PACKETS_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_FORCE_SEND_QUEUED_PACKETS_DTO_PROXY()
    {
    }
}