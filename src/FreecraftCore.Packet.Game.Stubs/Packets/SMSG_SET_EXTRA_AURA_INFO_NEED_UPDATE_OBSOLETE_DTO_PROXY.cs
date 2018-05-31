using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_SET_EXTRA_AURA_INFO_NEED_UPDATE_OBSOLETE)]
[WireDataContractAttribute]
public sealed class SMSG_SET_EXTRA_AURA_INFO_NEED_UPDATE_OBSOLETE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_SET_EXTRA_AURA_INFO_NEED_UPDATE_OBSOLETE_DTO_PROXY()
    {
    }
}