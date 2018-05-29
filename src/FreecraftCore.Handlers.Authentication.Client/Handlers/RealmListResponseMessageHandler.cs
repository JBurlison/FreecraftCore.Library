using System;
using System.Threading.Tasks;
using GladNet;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public class RealmListResponseMessageHandler : IPeerPayloadSpecificMessageHandler<AuthRealmListResponse, AuthenticationClientPayload>
	{
		private Func<byte[], RealmListContainer> RealmListDeserializer { get; }

		public RealmListResponseMessageHandler([NotNull] Func<byte[], RealmListContainer> realmListDeserializer)
		{
			RealmListDeserializer = realmListDeserializer ?? throw new ArgumentNullException(nameof(realmListDeserializer));
		}

		/// <inheritdoc />
		public Task HandleMessage(IPeerMessageContext<AuthenticationClientPayload> context, AuthRealmListResponse payload)
		{
			Console.WriteLine($"PayloadSize: {payload.PayloadSize}");
			Console.WriteLine($"{payload.isValid}");

			foreach(var realm in payload.Realms)
				Console.WriteLine($"Realm: {realm.ToString()}");

			//Console.WriteLine($"Byte Length: {payload.RealmBytes.Length}");

			//Console.WriteLine($"Bytes: {payload.RealmBytes.Aggregate("", (s, b) => $"{s} {b}")}");
			//Console.WriteLine($"UnknownTwo: {payload.unknownTwo} (should be 16)");

			//RealmListContainer container = RealmListDeserializer(payload.RealmBytes);

			//Console.WriteLine($"Container Size: {container.Realms.Count()}");

			//foreach(var realm in container.Realms)
			//	Console.WriteLine($"Realm: {realm.ToString()}");

			return Task.CompletedTask;
		}
	}
}
