using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.MSG_VIEW_PHASE_SHIFT)]
[WireDataContractAttribute]
public sealed class MSG_VIEW_PHASE_SHIFT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public MSG_VIEW_PHASE_SHIFT_DTO_PROXY()
    {
    }
}