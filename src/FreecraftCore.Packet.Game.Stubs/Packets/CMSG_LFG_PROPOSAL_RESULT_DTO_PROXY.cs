using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_LFG_PROPOSAL_RESULT)]
[WireDataContractAttribute]
public sealed class CMSG_LFG_PROPOSAL_RESULT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_LFG_PROPOSAL_RESULT_DTO_PROXY()
    {
    }
}