using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Logging;
using GladNet;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class AuthRealmListRequestHandler : IPeerPayloadSpecificMessageHandler<AuthRealmListRequest, AuthenticationServerPayload, IPeerSessionMessageContext<AuthenticationServerPayload>>
	{
		private ILog Logger { get; }

		/// <summary>
		/// Service that can provided the realm list information.
		/// </summary>
		private IRepositoryServiceFactory<IAuthenticationRealmRepository> RealmListService { get; }

		private INetworkSerializationService Serializer { get; }

		/// <inheritdoc />
		public AuthRealmListRequestHandler([NotNull] IRepositoryServiceFactory<IAuthenticationRealmRepository> realmListService, [NotNull] ILog logger, INetworkSerializationService serializer)
		{
			if(realmListService == null) throw new ArgumentNullException(nameof(realmListService));
			if(logger == null) throw new ArgumentNullException(nameof(logger));

			RealmListService = realmListService;
			Logger = logger;
			Serializer = serializer;
		}

		/// <inheritdoc />
		public async Task HandleMessage(IPeerSessionMessageContext<AuthenticationServerPayload> context, AuthRealmListRequest payload)
		{
			if(Logger.IsDebugEnabled)
				Logger.Debug($"Recieved {payload.GetType().Name} From ConnectionId: {context.Details.ConnectionId}");

			//All we need to do when we recieve this request
			//is send back a list of requests. It doesn't even technically matter if they're authenticated
			//or if they even provided the challenge/proof and failed.
			using(IAuthenticationRealmRepository realmService = RealmListService.Create())
			{
				IEnumerable<Realmlist> realms = await realmService.Retrieve();

				if(Logger.IsDebugEnabled)
					Logger.Debug($"Recieved RealmList repository response.");

				//TODO: Implement complete realm info handling; right now only uses default
				//TODO: Better handle handle other realm types. Resitrcted, dev, test or locked types.
				RealmInfo[] realmInfos = realms
					.Select(BuildRealmInfoFromModel)
					.ToArray();

				RealmListContainer realmListContainer = new RealmListContainer(realmInfos);

				byte[] realmData = Serializer.Serialize(realmListContainer);

				AuthRealmListResponse response = new AuthRealmListResponse((ushort)(realmData.Length + 6), realmInfos);

				if(Logger.IsDebugEnabled)
					Logger.Debug($"Sending {typeof(AuthRealmListResponse).Name} PayloadSize: {response.PayloadSize}.");

				await context.PayloadSendService.SendMessage(response);
			}
		}

		private static RealmInfo BuildRealmInfoFromModel(Realmlist realm)
		{
			//TODO: Handle realm version/build info better
			RealmBuildInformation buildInfo = new RealmBuildInformation(ExpansionType.WrathOfTheLichKing, 3, 5, (short)(realm.Gamebuild & 0xFF));

			DefaultRealmInformation information = new DefaultRealmInformation((RealmFlags)realm.Flag, realm.Name, new RealmEndpoint($"{realm.Address}:{realm.Port}"), 0, 0, realm.Timezone, (byte)realm.Id);

			//TODO: Implement character count query
			//TODO: Implement float??? population
			return information.Flags.HasFlag(RealmFlags.SpecifyBuild) 
				? new RealmInfo((RealmType)realm.Icon, false, information, buildInfo) 
				: new RealmInfo((RealmType)realm.Icon, false, information);
		}
	}
}
