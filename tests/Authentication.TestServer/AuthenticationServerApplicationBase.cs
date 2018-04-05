using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Common.Logging;
using Common.Logging.Simple;
using FreecraftCore;
using FreecraftCore.API.Common;
using FreecraftCore.Packet.Auth;
using FreecraftCore.Serializer;
using GladNet;
using JetBrains.Annotations;

namespace Authentication.TestServer
{
	public sealed class AuthenticationServerApplicationBase : TcpServerServerApplicationBase<AuthenticationServerPayload, AuthenticationClientPayload>
	{
		/// <summary>
		/// Application logger.
		/// </summary>
		public ILog Logger { get; }

		private INetworkSerializationService Serializer { get; }

		private IContainer ServiceContainer { get; }

		/// <inheritdoc />
		public AuthenticationServerApplicationBase([NotNull] NetworkAddressInfo serverAddress, [NotNull] ILog logger) 
			: base(serverAddress)
		{
			if(serverAddress == null) throw new ArgumentNullException(nameof(serverAddress));
			if(logger == null) throw new ArgumentNullException(nameof(logger));

			Logger = logger;
			Serializer = new FreecraftCoreGladNetSerializerAdapter(CreateSerializer());
			ServiceContainer = BuildServiceContainer();
		}

		private IContainer BuildServiceContainer()
		{
			ContainerBuilder builder = new ContainerBuilder();

			//TODO: Implement proper handler discovery.
			builder.RegisterInstance(new AuthLogonChallengeRequestHandler(Logger).AsTryHandler<AuthLogonChallengeRequest, AuthenticationClientPayload, AuthenticationServerPayload>())
				.As<IPeerMessageHandler<AuthenticationClientPayload, AuthenticationServerPayload>>();

			builder.RegisterType<AuthDefaultRequestHandler>()
				.AsImplementedInterfaces()
				.SingleInstance();

			builder.RegisterInstance(Logger)
				.As<ILog>();

			builder.RegisterType<MessageHandlerService<AuthenticationClientPayload, AuthenticationServerPayload>>()
				.As<MessageHandlerService<AuthenticationClientPayload, AuthenticationServerPayload>>()
				.SingleInstance();

			return builder.Build();
		}

		private ISerializerService CreateSerializer()
		{
			SerializerService serializer = new SerializerService();

			typeof(AuthLogonChallengeRequest).Assembly
				.GetTypes()
				.Where(t => typeof(AuthenticationServerPayload).IsAssignableFrom(t) || typeof(AuthenticationClientPayload).IsAssignableFrom(t))
				.ToList()
				.ForEach(t =>
				{
					serializer.RegisterType(t);
				});

			serializer.Compile();

			return serializer;
		}

		/// <inheritdoc />
		protected override bool IsClientAcceptable(TcpClient tcpClient)
		{
			return true;
		}

		/// <inheritdoc />
		protected override IManagedNetworkServerClient<AuthenticationServerPayload, AuthenticationClientPayload> CreateIncomingSessionPipeline(TcpClient client)
		{
			Console.WriteLine($"Client Connected: {(client.Client.RemoteEndPoint as IPEndPoint)?.Address.ToString()}");

			//The auth server is encryptionless and headerless
			IManagedNetworkServerClient<AuthenticationServerPayload, AuthenticationClientPayload> managedClient = new DotNetTcpClientNetworkClient(client)
				.AddHeaderlessNetworkMessageReading(Serializer)
				.For<AuthenticationClientPayload, AuthenticationServerPayload, IAuthenticationPayload>()
				.Build()
				.AsManagedSession(Logger);

			return managedClient;
		}

		/// <inheritdoc />
		protected override ManagedClientSession<AuthenticationServerPayload, AuthenticationClientPayload> CreateIncomingSession(IManagedNetworkServerClient<AuthenticationServerPayload, AuthenticationClientPayload> client)
		{
			//TODO: This is ugly clean it up
			//TODO: Expose a way to get incoming connection address
			return new AuthServerClientSession(client, new NetworkAddressInfo(IPAddress.Any, 50), ServiceContainer.Resolve<MessageHandlerService<AuthenticationClientPayload, AuthenticationServerPayload>>());
		}
	}
}
