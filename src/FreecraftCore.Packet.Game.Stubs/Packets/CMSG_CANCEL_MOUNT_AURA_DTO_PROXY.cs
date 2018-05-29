using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CANCEL_MOUNT_AURA)]
[WireDataContractAttribute]
public sealed class CMSG_CANCEL_MOUNT_AURA_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_CANCEL_MOUNT_AURA_DTO_PROXY()
    {
    }
}