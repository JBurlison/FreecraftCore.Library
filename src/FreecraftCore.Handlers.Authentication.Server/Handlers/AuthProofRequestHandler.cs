using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using FreecraftCore.Crypto;
using FreecraftCore.Packet.Auth;
using GladNet;
using JetBrains.Annotations;
using Reinterpret.Net;

namespace FreecraftCore
{
	public sealed class AuthProofRequestHandler : IPeerPayloadSpecificMessageHandler<AuthLogonProofRequest, AuthenticationServerPayload, IPeerSessionMessageContext<AuthenticationServerPayload>>
	{
		private ILog Logger { get; }

		/// <summary>
		/// Repository service.
		/// </summary>
		private IAuthenticationAuthChallengeRepository ChallengeRepository { get; }

		private IAuthenticationUserAccountRepository AccountRepository { get; }

		/// <summary>
		/// A combined static hash of sorts between SRP6 N and G.
		/// </summary>
		public static BigInteger T3 { get; } = ComputeT3();

		private static BigInteger ComputeT3()
		{
			using(WoWSRP6PublicComponentHashServiceProvider hasher = new WoWSRP6PublicComponentHashServiceProvider())
			{
				BigInteger N = WoWSRP6ServerCryptoServiceProvider.N;
				BigInteger G = WoWSRP6ServerCryptoServiceProvider.G;

				BigInteger nHash = hasher.Hash(N.ToCleanByteArray())
					.Take(20)
					.ToArray()
					.ToBigInteger();

				BigInteger gHash = hasher.Hash(G.ToCleanByteArray())
					.ToBigInteger();

				return nHash ^ gHash;
			}
		}

		/// <inheritdoc />
		public AuthProofRequestHandler([NotNull] ILog logger, [NotNull] IAuthenticationAuthChallengeRepository challengeRepository, [NotNull] IAuthenticationUserAccountRepository accountRepository)
		{
			if(logger == null) throw new ArgumentNullException(nameof(logger));
			if(challengeRepository == null) throw new ArgumentNullException(nameof(challengeRepository));

			Logger = logger;
			ChallengeRepository = challengeRepository;
			AccountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
		}

		/// <inheritdoc />
		public async Task HandleMessage(IPeerSessionMessageContext<AuthenticationServerPayload> context, AuthLogonProofRequest payload)
		{
			if(Logger.IsDebugEnabled)
				Logger.Debug($"Recieved {payload.GetType().Name} Id: {context.Details.ConnectionId}");

			BigInteger A = payload.A.ToBigInteger();

			//SRP6 Safeguard from specification: A % N cannot be 0.
			if(A % WoWSRP6ServerCryptoServiceProvider.N == 0)
			{
				//TODO: This can't be 0 or it breaks
			}

			//Check if we have a challenge entry for this connection
			//TODO: Add proper response code
			if(!await ChallengeRepository.HasEntry(context.Details.ConnectionId))
			{
				await context.PayloadSendService.SendMessage(new AuthLogonProofResponse(new LogonProofFailure()));

				return;
			}

			//TODO: Refactor
			using(WoWSRP6PublicComponentHashServiceProvider hasher = new WoWSRP6PublicComponentHashServiceProvider())
			{
				AuthenticationChallengeModel challenge = await ChallengeRepository.Retrieve(context.Details.ConnectionId);

				byte[] hash = hasher.Hash(A, challenge.PublicB);

				// Both:  u = H(A, B)
				BigInteger u = hash
					.Take(20)
					.ToArray()
					.ToBigInteger();
				BigInteger N = WoWSRP6ServerCryptoServiceProvider.N;

				//Host:  S = (Av^u) ^ b (computes session key)
				BigInteger S = ((A * (challenge.V.ModPow(u, N)))) //TODO: Do we need % N here?
					.ModPow(challenge.PrivateB, N);

				//Host:  K = H(S)
				BigInteger K = hasher.HashSessionKey(S);

				byte[] preMHash = T3.ToCleanByteArray()
					.Concat(hasher.Hash(challenge.Identity.Reinterpret(Encoding.ASCII)).Take(20).ToArray())
					.Concat(challenge.Salt.ToCleanByteArray())
					.Concat(payload.A)
					.Concat(challenge.PublicB.ToCleanByteArray())
					.Concat(K.ToCleanByteArray())
					.ToArray();

				byte[] M = hasher.Hash(preMHash);

				Logger.Debug($"M: {M.Aggregate("", (s, b) => $"{s} {b}")}");
				Logger.Debug($"M1: {payload.M1.Aggregate("", (s, b) => $"{s} {b}")}");

				//TODO: Remove this test code
				if(TestClass.CompareBuffers(M, payload.M1, 20) == 0)
				{
					Logger.Debug($"Auth Proof Success.");

					byte[] M2 = hasher.Hash(payload.A.Concat(M).Concat(K.ToCleanByteArray()).ToArray());

					//TODO: We also want to update last/login IP and other stuff
					await AccountRepository.UpdateSessionKey(challenge.AccountId, K);

					await context.PayloadSendService.SendMessage(new AuthLogonProofResponse(new LogonProofSuccess(M2)));
				}
				else
				{
					Logger.Debug($"Auth Proof Failure.");

					await context.PayloadSendService.SendMessage(new AuthLogonProofResponse(new LogonProofFailure()));
				}
			}

			//TODO: Implement
		}
	}

	public static class TestClass
	{
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe int memcmp(byte* b1, byte* b2, int count);

		public static unsafe int CompareBuffers(byte[] buffer1, byte[] buffer2, int count)
		{
			fixed (byte* b1 = buffer1, b2 = buffer2)
			{
				return memcmp(b1, b2, count);
			}
		}
	}

	
}
