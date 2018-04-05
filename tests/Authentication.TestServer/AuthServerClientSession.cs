using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.API.Common;
using FreecraftCore.Packet.Auth;
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
		private MessageHandlerService<AuthenticationClientPayload, AuthenticationServerPayload> AuthMessageHandlerService { get; }

		public static IPeerRequestSendService<AuthenticationServerPayload> MockedInterceptor { get; }

		static AuthServerClientSession()
		{
			MockedInterceptor = Mock.Of<IPeerRequestSendService<AuthenticationServerPayload>>();
		}

		/// <inheritdoc />
		public AuthServerClientSession(IManagedNetworkServerClient<AuthenticationServerPayload, AuthenticationClientPayload> internalManagedNetworkClient, NetworkAddressInfo clientAddress, [NotNull] MessageHandlerService<AuthenticationClientPayload, AuthenticationServerPayload> authMessageHandlerService) 
			: base(internalManagedNetworkClient, clientAddress)
		{
			if(authMessageHandlerService == null) throw new ArgumentNullException(nameof(authMessageHandlerService));

			AuthMessageHandlerService = authMessageHandlerService;
		}

		/// <inheritdoc />
		public override Task OnNetworkMessageRecieved(NetworkIncomingMessage<AuthenticationClientPayload> message)
		{
			//TODO: How should we handle server not having interceptor
			return AuthMessageHandlerService.TryHandleMessage(new DefaultPeerMessageContext<AuthenticationServerPayload>(Connection, SendService, MockedInterceptor), message);
		}
	}
}
