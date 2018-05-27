using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using FreecraftCore;
using FreecraftCore;
using FreecraftCore;
using FreecraftCore.Crypto;
using FreecraftCore;
using GladNet;
using JetBrains.Annotations;

namespace Authentication.TestServer
{
	//TODO: This is just a test/demo handler
	public sealed class AuthLogonChallengeRequestHandler : IPeerPayloadSpecificMessageHandler<AuthLogonChallengeRequest, AuthenticationServerPayload, IPeerSessionMessageContext<AuthenticationServerPayload>>
	{
		private ILog Logger { get; }

		/// <summary>
		/// Repository service.
		/// </summary>
		private IRepositoryServiceFactory<IAuthenticationUserAccountRepository> AccountRepository { get; }

		/// <summary>
		/// Challenge repository.
		/// </summary>
		private IAuthenticationAuthChallengeRepository ChallengeRepository { get; }

		/// <inheritdoc />
		public AuthLogonChallengeRequestHandler([NotNull] ILog logger, [NotNull] IRepositoryServiceFactory<IAuthenticationUserAccountRepository> accountRepository, 
			[NotNull] IAuthenticationAuthChallengeRepository challengeRepository)
		{
			if(logger == null) throw new ArgumentNullException(nameof(logger));
			if(accountRepository == null) throw new ArgumentNullException(nameof(accountRepository));
			if(challengeRepository == null) throw new ArgumentNullException(nameof(challengeRepository));

			Logger = logger;
			AccountRepository = accountRepository;
			ChallengeRepository = challengeRepository;
		}

		/// <inheritdoc />
		public async Task HandleMessage(IPeerSessionMessageContext<AuthenticationServerPayload> context, AuthLogonChallengeRequest payload)
		{
			using(var repo = AccountRepository.Create())
			{
				bool accountExists = await repo.DoesAccountExists(payload.Identity)
					.ConfigureAwait(false);

				if(Logger.IsDebugEnabled)
					Logger.Debug($"Account: {payload.Identity} Exists: {accountExists} ConnectionId: {context.Details.ConnectionId}");

				//Depending on if it exists we build an appropriate response
				AuthLogonChallengeResponse response = accountExists
					? await BuildSuccessResponse(await repo.GetAccount(payload.Identity).ConfigureAwait(false), context.Details.ConnectionId)
					: BuildFailureResponse();

				await context.PayloadSendService.SendMessage(response)
					.ConfigureAwait(false);
			}
		}

		//TODO: Handle all failure scenarios like ban/lock/etc
		private AuthLogonChallengeResponse BuildFailureResponse()
		{
			return new AuthLogonChallengeResponse(AuthenticationResult.FailUnknownAccount);
		}

		private async Task<AuthLogonChallengeResponse> BuildSuccessResponse([NotNull] Account account, int connectionId)
		{
			if(account == null) throw new ArgumentNullException(nameof(account));

			//TODO: unit test this
			using(WoWSRP6ServerCryptoServiceProvider srp = new WoWSRP6ServerCryptoServiceProvider(account.V))
			{
				//TODO: Add a hexstring extension method
				BigInteger PrivateB = srp.GeneratePrivateB();
				BigInteger PublicB = srp.GeneratePublicB(PrivateB);

				byte[] salt = account.S.ToBigInteger().ToCleanByteArray();
				byte[] G = WoWSRP6ServerCryptoServiceProvider.G.ToCleanByteArray();
				byte[] N = WoWSRP6ServerCryptoServiceProvider.N.ToCleanByteArray();

				SRPToken srpToken = new SRPToken(PublicB.ToCleanByteArray(), G, N, salt);

				//TODO: Check if entry already exists.
				await ChallengeRepository.TryCreate(connectionId, new AuthenticationChallengeModel(PublicB, srp.V, PrivateB, salt.ToBigInteger(), account.Username, account.Id));

				return new AuthLogonChallengeResponse(srpToken);
			}
		}
	}
}
