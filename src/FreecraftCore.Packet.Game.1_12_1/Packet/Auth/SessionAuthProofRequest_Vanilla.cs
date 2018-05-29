using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// The 1.12.1 implementation of the <see cref="NetworkOperationCode.CMSG_AUTH_SESSION"/>.
	/// </summary>
	[ForClientBuild(ClientBuild.Vanilla_1_12_1)]
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.CMSG_AUTH_SESSION)]
	[ProtocolGrouping(ProtocolCode.Authentication)] //Though this isn't part of the actual authserver stuff it's still auth.
	public class SessionAuthProofRequest_Vanilla : GamePacketPayload
	{
		/// <summary>
		/// The build number of the client.
		/// </summary>
		[WireMember(1)]
		public ClientBuild ClientBuildNumber { get; private set; }

		//For some reason Trinitycore expects a 4 byte clientbuild number
		//But clientbuild number is only a short, on the authentication process,
		//so it's likely these are unknown bytes
		[WireMember(2)]
		private short unknownOne { get; set; } = 0;

		//Not checked on Trinitycore
		//Was probably used for loadbalancing so it knows
		//which server to ask for the session key.
		//Skipped on Mangos too, with read_skip<uint32>()
		[WireMember(3)]
		private int LoginServiceId { get; set; } = 0;

		/// <summary>
		/// The account name attempting to authentication their session.
		/// </summary>
		[WireMember(4)]
		public string AccountName { get; private set; } //is a null terminated string

		//LoginServerType is not in the 1.12.1 packet

		//Mangos treats this as a uint32 but this is ok. It's 4 byte size.
		/// <summary>
		/// The client's randomly generated seed.
		/// </summary>
		[NotNull]
		[KnownSize(4)]
		[WireMember(6)]
		public byte[] RandomSeedBytes { get; private set; }

		//Mangos does not accept RealmIdentification RealmIdentity
		//Mangos does not accept ulong DosResponse

		/// <summary>
		/// The client's computed digest for session authentication.
		/// </summary>
		[NotNull]
		[KnownSize(20)]
		[WireMember(9)]
		public byte[] SessionDigest { get; private set; }

		//Mangos does not accept AddonChecksumsContainer BlizzardAddonVerificationContainer

		public SessionAuthProofRequest_Vanilla(ClientBuild clientBuildNumber, [NotNull] string accountName, [NotNull] byte[] randomSeedBytes,
			[NotNull] byte[] sessionDigest)
		{
			if(!Enum.IsDefined(typeof(ClientBuild), clientBuildNumber))
				throw new ArgumentOutOfRangeException(nameof(clientBuildNumber), "Value should be defined in the ClientBuild enum.");

			if(string.IsNullOrEmpty(accountName))
				throw new ArgumentException("Value cannot be null or empty.", nameof(accountName));

			ClientBuildNumber = clientBuildNumber;
			AccountName = accountName;
			RandomSeedBytes = randomSeedBytes;
			SessionDigest = sessionDigest;
		}

		protected SessionAuthProofRequest_Vanilla()
		{
			//protected ctor for serialization
		}
	}
}
