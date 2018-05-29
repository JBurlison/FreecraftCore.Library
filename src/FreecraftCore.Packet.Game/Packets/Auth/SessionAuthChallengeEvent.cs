using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// First message sent by the server after connections (as an event)
	/// and is used to authenticate a session on that server.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_AUTH_CHALLENGE)] //the packet the worldserver first sends
	[ProtocolGrouping(ProtocolCode.Authentication)] //Though this isn't part of the actual authserver stuff it's still auth.
	public class SessionAuthChallengeEvent : GamePacketPayload
	{
		//Trinitycore always sends 1
		//Not sure what this is
		//It is not sent in 1.12.1 Mangos
		[WireMember(1)]
		private uint unknownOne { get; set; }

		/// <summary>
		/// The auth session challenge data.
		/// (Shared structure between 1.12.1 and 3.3.5)
		/// </summary>
		[WireMember(2)]
		public SessionAuthChallengeEventData EventData { get; }

		/// <inheritdoc />
		public SessionAuthChallengeEvent([NotNull] SessionAuthChallengeEventData eventData)
		{
			EventData = eventData ?? throw new ArgumentNullException(nameof(eventData));
		}

		public SessionAuthChallengeEvent()
		{
			//TODO: If we ever make a server we'll need a real ctor for this packet.
		}
	}
}
