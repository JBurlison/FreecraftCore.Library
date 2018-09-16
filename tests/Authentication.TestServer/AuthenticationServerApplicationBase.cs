using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Autofac;
using Common.Logging;
using FreecraftCore;
using FreecraftCore.Serializer;
using GladNet;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

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
			: base(serverAddress, logger)
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

			builder.RegisterInstance(Serializer)
				.As<INetworkSerializationService>();

			builder.RegisterType<AuthDefaultRequestHandler>()
				.AsImplementedInterfaces()
				.SingleInstance();

			builder.RegisterInstance(Logger)
				.As<ILog>();

			builder.RegisterType<MessageHandlerService<AuthenticationClientPayload, AuthenticationServerPayload, IPeerSessionMessageContext<AuthenticationServerPayload>>>()
				.As<MessageHandlerService<AuthenticationClientPayload, AuthenticationServerPayload, IPeerSessionMessageContext<AuthenticationServerPayload>>>()
				.SingleInstance();

			//TODO: Maybe use ASP Core DI service so we can hide this stuff
			DbContextOptionsBuilder<authContext> authDatabaseBuilder = new DbContextOptionsBuilder<authContext>();
			authDatabaseBuilder.UseMySql(@"server=kurthoswow-test-db.c7tnrjczj0de.us-east-2.rds.amazonaws.com;port=3306;user=root;password=KurthosWoW;database=auth");

			//Add the database stuff
			builder.RegisterType<authContext>()
				.AsSelf()
				.InstancePerDependency();

			builder.RegisterType<AuthenticationDatabaseUserAccountAccountRepository>()
				.As<IAuthenticationUserAccountRepository>()
				.InstancePerDependency();

			builder.RegisterType<InvertedControlRepositoryServiceFactory<IAuthenticationUserAccountRepository>>()
				.As<IRepositoryServiceFactory<IAuthenticationUserAccountRepository>>()
				.SingleInstance();

			//This registers all the authentication message handlers
			builder.RegisterModule<AuthenticationHandlerRegisterationModule>();

			//TODO: We should move to service factory design
			builder.RegisterType<AuthenticationInMemoryAuthChallengeRepository>()
				.As<IAuthenticationAuthChallengeRepository>()
				.SingleInstance();

			//TODO: Make this registeration generic so we don't need 1:1 for each repository service
			builder.RegisterType<AuthenticationDatabaseRealmRepository>()
				.As<IAuthenticationRealmRepository>()
				.InstancePerDependency();

			builder.RegisterType<InvertedControlRepositoryServiceFactory<IAuthenticationRealmRepository>>()
				.As<IRepositoryServiceFactory<IAuthenticationRealmRepository>>()
				.SingleInstance();

			return builder.Build();
		}

		private ISerializerService CreateSerializer()
		{
			SerializerService serializer = new SerializerService();

			serializer.RegisterType<RealmListContainer>();

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
		protected override ManagedClientSession<AuthenticationServerPayload, AuthenticationClientPayload> CreateIncomingSession(IManagedNetworkServerClient<AuthenticationServerPayload, AuthenticationClientPayload> client, SessionDetails details)
		{
			return new AuthServerClientSession(client, details, ServiceContainer.Resolve<MessageHandlerService<AuthenticationClientPayload, AuthenticationServerPayload, IPeerSessionMessageContext<AuthenticationServerPayload>>>());
		}
	}
}
