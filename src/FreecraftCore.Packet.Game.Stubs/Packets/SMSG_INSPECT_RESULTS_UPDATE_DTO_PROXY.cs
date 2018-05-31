using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_INSPECT_RESULTS_UPDATE)]
[WireDataContractAttribute]
public sealed class SMSG_INSPECT_RESULTS_UPDATE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_INSPECT_RESULTS_UPDATE_DTO_PROXY()
    {
    }
}