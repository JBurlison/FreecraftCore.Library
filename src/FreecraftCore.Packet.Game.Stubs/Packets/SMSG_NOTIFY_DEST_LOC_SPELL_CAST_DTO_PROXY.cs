using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_NOTIFY_DEST_LOC_SPELL_CAST)]
[WireDataContractAttribute]
public sealed class SMSG_NOTIFY_DEST_LOC_SPELL_CAST_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_NOTIFY_DEST_LOC_SPELL_CAST_DTO_PROXY()
    {
    }
}