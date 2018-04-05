using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
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

		/// <inheritdoc />
		public AuthLogonChallengeRequestHandler([NotNull] ILog logger)
		{
			if(logger == null) throw new ArgumentNullException(nameof(logger));

			Logger = logger;
		}

		/// <inheritdoc />
		public async Task HandleMessage(IPeerMessageContext<AuthenticationServerPayload> context, AuthLogonChallengeRequest payload)
		{
			int currentCount = Interlocked.Add(ref Count, 1);

			//This is just demo code
			if(Logger.IsDebugEnabled)
				Logger.Debug($"ClientBuild: {payload.Build} Count: {currentCount}");

			AuthLogonChallengeResponse response = new AuthLogonChallengeResponse(AuthenticationResult.FailNoGameTime);

			await context.PayloadSendService.SendMessage(response);

			await context.ConnectionService.DisconnectAsync(1);
		}
	}
}
