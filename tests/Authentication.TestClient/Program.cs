using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using Common.Logging.Simple;
using FreecraftCore;
using FreecraftCore;
using FreecraftCore.Crypto;
using FreecraftCore;
using FreecraftCore;
using FreecraftCore.Serializer;
using GladNet;

namespace Authentication.TestClient
{
	class Program
	{
		public static SerializerService Serializer { get; private set; }

		public static int Count = 0;

		static async Task Main(string[] args)
		{
			Serializer = new SerializerService();

			typeof(AuthLogonChallengeRequest).Assembly
				.GetTypes()
				.Where(t => typeof(AuthenticationServerPayload).IsAssignableFrom(t) || typeof(AuthenticationClientPayload).IsAssignableFrom(t))
				.ToList()
				.ForEach(t =>
				{
					Serializer.RegisterType(t);
				});

			Serializer.RegisterType<RealmListContainer>();

			Serializer.Compile();

			await AsyncMain(BuildClient());


			Console.ReadKey();
		}

		private static IManagedNetworkClient<AuthenticationClientPayload, AuthenticationServerPayload> BuildClient()
		{
			//The auth server is encryptionless and headerless
			IManagedNetworkClient<AuthenticationClientPayload, AuthenticationServerPayload> client = new DotNetTcpClientNetworkClient()
				.AddHeaderlessNetworkMessageReading(new FreecraftCoreGladNetSerializerAdapter(Serializer))
				.For<AuthenticationServerPayload, AuthenticationClientPayload, IAuthenticationPayload>()
				.Build()
				.AsManaged(new ConsoleOutLogger("ConsoleLogger", LogLevel.All, true, false, false, null));

			return client;
		}

		private static async Task AsyncMain(IManagedNetworkClient<AuthenticationClientPayload, AuthenticationServerPayload> client)
		{
			try
			{
				if(!await client.ConnectAsync("127.0.0.1", 5050).ConfigureAwait(false))
					Console.WriteLine("Failed to connect");

				await client.SendMessage(new AuthLogonChallengeRequest(ProtocolVersion.ProtocolVersionTwo, GameType.WoW, ExpansionType.WrathOfTheLichKing, 3, 5,
						ClientBuild.Wotlk_3_3_5a, PlatformType.x86, OperatingSystemType.Win, LocaleType.enUS,
						IPAddress.Parse("127.0.0.1"), "Glader"))
					.ConfigureAwait(false);
			}
			catch(Exception e)
			{
				Console.WriteLine($"Error: {e.Message}");
			}

			while(true)
			{
				var response = (await client.ReadMessageAsync()).Payload;

				Console.WriteLine("Recieved payload");

				AuthenticationLogonChallengeResponseMessageHandler handler = new AuthenticationLogonChallengeResponseMessageHandler();

				AuthenticationLogonProofResponseMessageHandler proofHandler = new AuthenticationLogonProofResponseMessageHandler();

				RealmListResponseMessageHandler realmListResponseHandler = new RealmListResponseMessageHandler(bytes => Serializer.Deserialize<RealmListContainer>(bytes));

				if(response is AuthLogonChallengeResponse challengeResponse)
				{
					Console.WriteLine($"Response: Valid: {challengeResponse.isValid} Result: {challengeResponse.Result} SRP: {challengeResponse.Challenge}");

					await handler.HandleMessage(new DefaultPeerMessageContext<AuthenticationClientPayload>(client, client, new PayloadInterceptMessageSendService<AuthenticationClientPayload>(client, client)), challengeResponse);
				}
				else if(response is AuthRealmListResponse realmListResponse)
					await realmListResponseHandler.HandleMessage(new DefaultPeerMessageContext<AuthenticationClientPayload>(client, client, new PayloadInterceptMessageSendService<AuthenticationClientPayload>(client, client)), realmListResponse);
				else if(response is AuthLogonProofResponse proofResponse)
					await proofHandler.HandleMessage(new DefaultPeerMessageContext<AuthenticationClientPayload>(client, client, new PayloadInterceptMessageSendService<AuthenticationClientPayload>(client, client)), proofResponse);
			}
		}
	}
}
