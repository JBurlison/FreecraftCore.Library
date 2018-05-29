using System;
using System.Threading.Tasks;
using FreecraftCore;
using GladNet;
using JetBrains.Annotations;
using Moq;

namespace Authentication.TestServer
{
	public sealed class AuthServerClientSession : ManagedClientSession<AuthenticationServerPayload, AuthenticationClientPayload>
	{
		/// <summary>
		/// The message handling service for auth messages.
		/// </summary>
		private MessageHandlerService<AuthenticationClientPayload, AuthenticationServerPayload, IPeerSessionMessageContext<AuthenticationServerPayload>> AuthMessageHandlerService { get; }

		public static IPeerRequestSendService<AuthenticationServerPayload> MockedInterceptor { get; }

		static AuthServerClientSession()
		{
			MockedInterceptor = Mock.Of<IPeerRequestSendService<AuthenticationServerPayload>>();
		}

		/// <inheritdoc />
		public AuthServerClientSession(IManagedNetworkServerClient<AuthenticationServerPayload, AuthenticationClientPayload> internalManagedNetworkClient, SessionDetails details, 
			[NotNull] MessageHandlerService<AuthenticationClientPayload, AuthenticationServerPayload, IPeerSessionMessageContext<AuthenticationServerPayload>> authMessageHandlerService) 
			: base(internalManagedNetworkClient, details)
		{
			if(authMessageHandlerService == null) throw new ArgumentNullException(nameof(authMessageHandlerService));

			AuthMessageHandlerService = authMessageHandlerService;
		}

		/// <inheritdoc />
		public override Task OnNetworkMessageRecieved(NetworkIncomingMessage<AuthenticationClientPayload> message)
		{
			//TODO: How should we handle server not having interceptor
			return AuthMessageHandlerService.TryHandleMessage(new AuthSessionMessageContext(Connection, SendService, MockedInterceptor, Details), message);
		}

		/// <inheritdoc />
		protected override void OnSessionDisconnected()
		{
			//TODO: Do session cleanup if we need it
		}
	}
}
