using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreecraftCore.API.Common;
using FreecraftCore.Packet.Auth;
using FreecraftCore.Packet.Common;
using GladNet;
using JetBrains.Annotations;

namespace FreecraftCore.Handlers
{
	public class RealmListResponseMessageHandler : IPeerPayloadSpecificMessageHandler<AuthRealmListResponse, AuthenticationClientPayload>
	{
		/// <inheritdoc />
		public Task HandleMessage(IPeerMessageContext<AuthenticationClientPayload> context, AuthRealmListResponse payload)
		{
			Console.WriteLine($"PayloadSize: {payload.PayloadSize}");
			Console.WriteLine($"{payload.isValid}");
			
			Console.WriteLine($"Byte Length: {payload.RealmBytes.Length}");

			Console.WriteLine($"Bytes: {payload.RealmBytes.Aggregate("", (s, b) => $"{s} {b}")}");

			return Task.CompletedTask;
		}
	}
}
