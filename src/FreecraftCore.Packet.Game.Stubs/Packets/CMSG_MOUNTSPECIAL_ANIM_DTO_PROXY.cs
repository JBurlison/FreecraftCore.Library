using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_MOUNTSPECIAL_ANIM)]
[WireDataContractAttribute]
public sealed class CMSG_MOUNTSPECIAL_ANIM_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_MOUNTSPECIAL_ANIM_DTO_PROXY()
    {
    }
}