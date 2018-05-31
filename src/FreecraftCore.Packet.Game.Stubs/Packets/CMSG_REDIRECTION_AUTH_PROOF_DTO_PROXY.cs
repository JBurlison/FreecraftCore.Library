using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_REDIRECTION_AUTH_PROOF)]
[WireDataContractAttribute]
public sealed class CMSG_REDIRECTION_AUTH_PROOF_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
{
    [ReadToEndAttribute]
    [WireMemberAttribute(1)]
    private byte[] _Data;
    public byte[] Data
    {
        get
        {
            return _Data;
        }

        set
        {
            _Data = value;
        }
    }

    public CMSG_REDIRECTION_AUTH_PROOF_DTO_PROXY()
    {
    }
}