using FreecraftCore.API.Common;
using FreecraftCore.API.Common.Auth;
using FreecraftCore.Packet.Common;
using FreecraftCore.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace FreecraftCore.Packet.Auth
{
	/// <summary>
	/// The response payload to a <see cref="AuthLogonChallengeRequest"/>.
	/// </summary>
	[WireDataContract]
	[AuthenticationServerPayload(AuthOperationCode.AUTH_LOGON_CHALLENGE)] //TODO: Figure out how to support linking with the limited information.
	public class AuthLogonChallengeResponse : AuthenticationServerPayload
	{
		//TODO: Implement
		public override bool isValid { get; } = true;

		/// <summary>
		/// Unknown 0x00 byte sent from the server.
		/// </summary>
		[WireMember(1)]
		public readonly byte unknownResponseByte = 0;

		//Second piece of data sent is a result
		[WireMember(2)]
		public AuthenticationResult Result { get; private set; }

		/// <summary>
		/// Bool used to compute optional read/write for response payload fields
		/// that involved the SRP.
		/// </summary>
		public bool isAuthenticationChallengeSuccessful => Result == AuthenticationResult.Success || Result == AuthenticationResult.Success_Survey;

		/// <summary>
		/// The SRP6 challenge provided by the server.
		/// See: http://srp.stanford.edu/design.html for more information
		/// </summary>
		[Optional(nameof(isAuthenticationChallengeSuccessful))]
		[WireMember(3)]
		public SRPToken Challenge { get; private set; }

		/// <summary>
		/// Seed to be used during HMAC of the client files.
		/// (Not implemented in Trinitycore or Mangos)
		/// </summary>
		[Optional(nameof(isAuthenticationChallengeSuccessful))]
		[KnownSize(16)]
		[WireMember(4)]
		public byte[] ClientFileHMACSeed { get; private set; }

		//TODO: Create enum
		/// <summary>
		/// Flags that indicate what security additional measures are required for authentication
		/// (Ex. Authenticator or Pin) Will usually be 0 meaning none
		/// </summary>
		[Optional(nameof(isAuthenticationChallengeSuccessful))]
		[WireMember(5)]
		public byte securityFlags { get; private set; }

		//The server is suppose to send additional info depending on the flags
		//However, the serializer isn't capable of conditionally reading different sizes based on flags
		//It's all just 0s or constants anyway in Trinitycore

		//If this is true then it will contain token data
		[Obsolete("Use success property.")]
		public bool isSuccess()
		{
			return Result == AuthenticationResult.Success || Result == AuthenticationResult.Success_Survey;
		}

		public AuthLogonChallengeResponse(AuthenticationResult result)
		{
			if(!Enum.IsDefined(typeof(AuthenticationResult), result)) throw new ArgumentOutOfRangeException(nameof(result), "Value should be defined in the AuthenticationResult enum.");

			Result = result;

			if(isAuthenticationChallengeSuccessful)
				throw new InvalidOperationException($"Cannot initialize {nameof(Result)} as {AuthenticationResult.Success} without fully intializing payload.");
		}

		//TODO: Proper ctor; right now we don't have a server so we can get away with just default

		public AuthLogonChallengeResponse()
		{

		}
	}
}
