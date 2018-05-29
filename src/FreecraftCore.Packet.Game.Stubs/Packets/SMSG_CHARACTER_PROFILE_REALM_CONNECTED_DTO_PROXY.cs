using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_CHARACTER_PROFILE_REALM_CONNECTED)]
[WireDataContractAttribute]
public sealed class SMSG_CHARACTER_PROFILE_REALM_CONNECTED_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_CHARACTER_PROFILE_REALM_CONNECTED_DTO_PROXY()
    {
    }
}