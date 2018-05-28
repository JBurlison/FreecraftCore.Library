using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using FreecraftCore;
using FreecraftCore.Crypto;
using FreecraftCore;
using FreecraftCore;
using FreecraftCore;
using GladNet;
using JetBrains.Annotations;
using BigInteger = FreecraftCore.Crypto.BigInteger;

namespace FreecraftCore
{
	//TODO: Do we even want a handler? We might just want to intercept the response.
	//TODO: Add dependencies for auth details and such.
	/// <summary>
	/// Handler that handles the <see cref="AuthLogonChallengeResponse"/>.
	/// </summary>
	public class AuthenticationLogonChallengeResponseMessageHandler : IPeerPayloadSpecificMessageHandler<AuthLogonChallengeResponse, AuthenticationClientPayload>
	{
		public AuthenticationLogonChallengeResponseMessageHandler()
		{

		}

		/// <inheritdoc />
		public Task HandleMessage(IPeerMessageContext<AuthenticationClientPayload> context, AuthLogonChallengeResponse payload)
		{
			AuthLogonProofRequest proof = null;

			//TODO: Change this console logging
			if(payload.Result != AuthenticationResult.Success)
				Console.WriteLine($"Failed Auth: {payload.Result}");

			using(WoWSRP6ClientCryptoServiceProvider srpProvider = new WoWSRP6ClientCryptoServiceProvider(payload.Challenge.B.ToBigInteger(), payload.Challenge.N.ToBigInteger(), payload.Challenge.g.ToBigInteger()))
			{
				using(WoWSRP6PublicComponentHashServiceProvider hashingService = new WoWSRP6PublicComponentHashServiceProvider())
				{
					//TODO: Remove hardcoded name/pass
					//Set the session key in the store for usage
					BigInteger unhashedKey = srpProvider.ComputeSessionKey("Glader".ToUpper(), "test", payload.Challenge.salt);

					Console.WriteLine($"SessionKey: {unhashedKey} KeySize: {unhashedKey.ToCleanByteArray().Length}");

					proof = new AuthLogonProofRequest(srpProvider.A.ToCleanByteArray(), hashingService.ComputeSRP6M1(srpProvider.g, srpProvider.N, "Glader".ToUpper(), payload.Challenge.salt, srpProvider.A, srpProvider.B, unhashedKey));

					//Set the session key as a hashed session key
					//SessionKeyStorage.SessionKey = hashingService.HashSessionKey(unhashedKey);
				}
			}

			Console.WriteLine("Sending Proof");

			return context.PayloadSendService.SendMessage(proof);
		}
	}
}
