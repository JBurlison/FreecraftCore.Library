using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using Common.Logging.Simple;
using FreecraftCore;
using FreecraftCore.API.Common;
using FreecraftCore.Packet.Auth;
using FreecraftCore.Serializer;
using GladNet;
using GladNet3;

namespace Authentication.TestServer
{
	public sealed class AuthenticationServerApplicationBase : TcpServerServerApplicationBase<AuthenticationServerPayload, AuthenticationClientPayload>
	{
		private INetworkSerializationService Serializer { get; }

		/// <inheritdoc />
		public AuthenticationServerApplicationBase(NetworkAddressInfo serverAddress) 
			: base(serverAddress)
		{
			Serializer = new FreecraftCoreGladNetSerializerAdapter(CreateSerializer());
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
		protected override async Task HandleIncomingNetworkMessage(IManagedNetworkClient<AuthenticationServerPayload, AuthenticationClientPayload> networkClient, NetworkIncomingMessage<AuthenticationClientPayload> message)
		{
			Console.WriteLine($"Recieved Payload: {message.Payload.GetType().Name}");

			//This is just demo code
			if(message.Payload is AuthLogonChallengeRequest c)
				Console.WriteLine($"ClientBuild: {c.Build.ToString()}");

			AuthLogonChallengeResponse response = new AuthLogonChallengeResponse(AuthenticationResult.FailNoGameTime);

			await networkClient.SendMessage(response);

			//await networkClient.DisconnectAsync(1);
		}

		/// <inheritdoc />
		protected override bool IsClientAcceptable(TcpClient tcpClient)
		{
			return true;
		}

		/// <inheritdoc />
		protected override IManagedNetworkClient<AuthenticationServerPayload, AuthenticationClientPayload> CreateIncomingClientPipeline(TcpClient client)
		{
			Console.WriteLine($"Client Connected: {(client.Client.RemoteEndPoint as IPEndPoint)?.Address.ToString()}");

			//The auth server is encryptionless and headerless
			IManagedNetworkClient<AuthenticationServerPayload, AuthenticationClientPayload> managedClient = new DotNetTcpClientNetworkClient(client)
				.AddHeaderlessNetworkMessageReading(Serializer)
				.For<AuthenticationClientPayload, AuthenticationServerPayload, IAuthenticationPayload>()
				.Build()
				.AsManaged(new ConsoleOutLogger("ConsoleLogger", LogLevel.All, true, false, false, null));

			return managedClient;
		}
	}
}
