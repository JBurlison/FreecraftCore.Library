using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_MOVE_FEATHER_FALL)]
[WireDataContractAttribute]
public sealed class SMSG_MOVE_FEATHER_FALL_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_MOVE_FEATHER_FALL_DTO_PROXY()
    {
    }
}