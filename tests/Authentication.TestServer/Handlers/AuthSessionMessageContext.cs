using System;
using FreecraftCore;
using GladNet;
using JetBrains.Annotations;

namespace Authentication
{
	//TODO: Refactor and extract this into common assembly and make it universal to all servers
	public sealed class AuthSessionMessageContext : IPeerSessionMessageContext<AuthenticationServerPayload>
	{
		/// <inheritdoc />
		public IConnectionService ConnectionService { get; }

		/// <inheritdoc />
		public IPeerPayloadSendService<AuthenticationServerPayload> PayloadSendService { get; }

		/// <inheritdoc />
		public IPeerRequestSendService<AuthenticationServerPayload> RequestSendService { get; }

		/// <inheritdoc />
		public SessionDetails Details { get; }

		/// <inheritdoc />
		public AuthSessionMessageContext([NotNull] IConnectionService connectionService, [NotNull] IPeerPayloadSendService<AuthenticationServerPayload> payloadSendService, [NotNull] IPeerRequestSendService<AuthenticationServerPayload> requestSendService, [NotNull] SessionDetails details)
		{
			if(connectionService == null) throw new ArgumentNullException(nameof(connectionService));
			if(payloadSendService == null) throw new ArgumentNullException(nameof(payloadSendService));
			if(requestSendService == null) throw new ArgumentNullException(nameof(requestSendService));
			if(details == null) throw new ArgumentNullException(nameof(details));

			ConnectionService = connectionService;
			PayloadSendService = payloadSendService;
			RequestSendService = requestSendService;
			Details = details;
		}
	}
}
