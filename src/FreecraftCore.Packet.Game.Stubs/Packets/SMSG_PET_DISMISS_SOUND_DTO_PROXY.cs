using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_PET_DISMISS_SOUND)]
[WireDataContractAttribute]
public sealed class SMSG_PET_DISMISS_SOUND_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_PET_DISMISS_SOUND_DTO_PROXY()
    {
    }
}