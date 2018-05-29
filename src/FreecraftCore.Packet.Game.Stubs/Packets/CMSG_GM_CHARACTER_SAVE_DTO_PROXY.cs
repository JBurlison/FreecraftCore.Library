using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_GM_CHARACTER_SAVE)]
[WireDataContractAttribute]
public sealed class CMSG_GM_CHARACTER_SAVE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_GM_CHARACTER_SAVE_DTO_PROXY()
    {
    }
}