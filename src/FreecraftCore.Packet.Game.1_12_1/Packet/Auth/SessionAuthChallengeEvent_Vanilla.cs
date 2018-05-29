using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Vanilla implementation of <see cref="NetworkOperationCode.SMSG_AUTH_CHALLENGE"/>
	/// First message sent by the server after connections (as an event)
	/// and is used to authenticate a session on that server.
	/// </summary>
	[ForClientBuild(ClientBuild.Vanilla_1_12_1)]
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_AUTH_CHALLENGE)] //the packet the worldserver first sends
	[ProtocolGrouping(ProtocolCode.Authentication)] //Though this isn't part of the actual authserver stuff it's still auth.
	public class SessionAuthChallengeEvent_Vanilla : GamePacketPayload
	{
		//Mangos does not send uint unknownOne

		/// <summary>
		/// The auth session challenge data.
		/// (Shared structure between 1.12.1 and 3.3.5)
		/// </summary>
		[WireMember(2)]
		public SessionAuthChallengeEventData EventData { get; }

		/// <inheritdoc />
		public SessionAuthChallengeEvent_Vanilla([NotNull] SessionAuthChallengeEventData eventData)
		{
			EventData = eventData ?? throw new ArgumentNullException(nameof(eventData));
		}

		public SessionAuthChallengeEvent_Vanilla()
		{
			//TODO: If we ever make a server we'll need a real ctor for this packet.
		}
	}
}
