using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_REPORT_PVP_AFK_RESULT)]
[WireDataContractAttribute]
public sealed class SMSG_REPORT_PVP_AFK_RESULT_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_REPORT_PVP_AFK_RESULT_DTO_PROXY()
    {
    }
}