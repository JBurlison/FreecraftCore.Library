using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_NEXT_CINEMATIC_CAMERA)]
[WireDataContractAttribute]
public sealed class CMSG_NEXT_CINEMATIC_CAMERA_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_NEXT_CINEMATIC_CAMERA_DTO_PROXY()
    {
    }
}