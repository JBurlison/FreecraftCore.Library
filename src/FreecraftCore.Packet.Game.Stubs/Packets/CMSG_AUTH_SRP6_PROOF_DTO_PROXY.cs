using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_AUTH_SRP6_PROOF)]
[WireDataContractAttribute]
public sealed class CMSG_AUTH_SRP6_PROOF_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_AUTH_SRP6_PROOF_DTO_PROXY()
    {
    }
}