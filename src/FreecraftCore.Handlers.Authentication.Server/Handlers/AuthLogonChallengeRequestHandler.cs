using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using FreecraftCore;
using FreecraftCore.API.Common;
using FreecraftCore.Packet.Auth;
using GladNet;
using JetBrains.Annotations;

namespace Authentication.TestServer
{
	//TODO: This is just a test/demo handler
	public sealed class AuthLogonChallengeRequestHandler : IPeerPayloadSpecificMessageHandler<AuthLogonChallengeRequest, AuthenticationServerPayload>
	{
		private ILog Logger { get; }

		private int Count = 0;

		/// <summary>
		/// Repository service.
		/// </summary>
		private IRepositoryServiceFactory<IAuthenticationUserAccountRepository> AccountRepository { get; }

		/// <inheritdoc />
		public AuthLogonChallengeRequestHandler([NotNull] ILog logger, [NotNull] IRepositoryServiceFactory<IAuthenticationUserAccountRepository> accountRepository)
		{
			if(logger == null) throw new ArgumentNullException(nameof(logger));
			if(accountRepository == null) throw new ArgumentNullException(nameof(accountRepository));

			Logger = logger;
			AccountRepository = accountRepository;
		}

		/// <inheritdoc />
		public async Task HandleMessage(IPeerMessageContext<AuthenticationServerPayload> context, AuthLogonChallengeRequest payload)
		{
			int currentCount = Interlocked.Add(ref Count, 1);

			//This is just demo code
			if(Logger.IsDebugEnabled)
				Logger.Debug($"ClientBuild: {payload.Build} Count: {currentCount}");

			using(var repo = AccountRepository.Create())
			{
				bool accountExists = await repo.DoesAccountExists(payload.Identity)
					.ConfigureAwait(false);

				if(Logger.IsDebugEnabled)
					Logger.Debug($"Account: {payload.Identity} Exists: {accountExists}");

				AuthLogonChallengeResponse response = new AuthLogonChallengeResponse(accountExists ? AuthenticationResult.FailBanned : AuthenticationResult.FailUnknownAccount);

				await context.PayloadSendService.SendMessage(response)
					.ConfigureAwait(false);
			}

			await context.ConnectionService.DisconnectAsync(1)
				.ConfigureAwait(false);
		}
	}
}
