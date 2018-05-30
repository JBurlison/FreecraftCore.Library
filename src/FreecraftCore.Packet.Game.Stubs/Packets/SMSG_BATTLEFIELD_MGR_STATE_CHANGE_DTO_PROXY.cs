using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_BATTLEFIELD_MGR_STATE_CHANGE)]
[WireDataContractAttribute]
public sealed class SMSG_BATTLEFIELD_MGR_STATE_CHANGE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_BATTLEFIELD_MGR_STATE_CHANGE_DTO_PROXY()
    {
    }
}