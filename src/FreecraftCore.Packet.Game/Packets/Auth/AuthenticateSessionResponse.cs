using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// The authentication response to <see cref="NetworkOperationCode.CMSG_AUTH_SESSION"/>
	/// Same for 1.12.1 and 3.3.5
	/// </summary>
	[ForClientBuild(ClientBuild.Wotlk_3_3_5a)]
	[ForClientBuild(ClientBuild.Vanilla_1_12_1)]
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_AUTH_RESPONSE)] //the response to a request to authenticate a session
	[ProtocolGrouping(ProtocolCode.Authentication)] //Though this isn't part of the actual authserver stuff it's still auth.
	public class AuthenticateSessionResponse : GamePacketPayload
	{
		/// <inheritdoc />
		public override bool isValid { get; } = true;

		/// <summary>
		/// Indicates the result of the session authentication.
		/// </summary>
		[WireMember(1)]
		public SessionAuthenticationResult AuthenticationResult { get; private set; }

		//TODO: Doc
		//TODO: We don't support queue/realmtransfer data in the packet because there is no way to determine it outside of length
		[WireMember(2)]
		public uint BillingTimeRemaining { get; }

		//TODO: Handle flags
		[WireMember(3)]
		public byte BillingPlanFlags { get; }

		//TODO: What is this?
		[WireMember(4)]
		public uint BillingTimeRested { get; }

		[WireMember(5)]
		public Expansions AccountExpansion { get; }

		public AuthenticateSessionResponse()
		{
			//TODO: If we ever run a server add a ctor
		}
	}
}
