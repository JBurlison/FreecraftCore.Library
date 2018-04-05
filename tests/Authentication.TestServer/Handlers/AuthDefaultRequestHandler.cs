using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using FreecraftCore.Packet.Auth;
using GladNet;
using JetBrains.Annotations;

namespace Authentication.TestServer
{
	public sealed class AuthDefaultRequestHandler : IPeerPayloadSpecificMessageHandler<AuthenticationClientPayload, AuthenticationServerPayload>
	{
		private ILog Logger { get; }

		/// <inheritdoc />
		public AuthDefaultRequestHandler([NotNull] ILog logger)
		{
			if(logger == null) throw new ArgumentNullException(nameof(logger));

			Logger = logger;
		}

		/// <inheritdoc />
		public Task HandleMessage(IPeerMessageContext<AuthenticationServerPayload> context, AuthenticationClientPayload payload)
		{
			if(Logger.IsWarnEnabled)
				Logger.Warn($"Recieved unhandable Payload: {payload.GetType().Name} From: {"TODO"}");

			return Task.CompletedTask;
		}
	}
}
