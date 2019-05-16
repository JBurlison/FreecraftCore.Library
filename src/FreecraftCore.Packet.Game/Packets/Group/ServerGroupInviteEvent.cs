using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_GROUP_INVITE)]
	public sealed class ServerGroupInviteEvent : GamePacketPayload
	{
		//TC sends 0 or 1. 1 when it's successful. 0 when the target player is already in a group.
		/// <summary>
		/// Indicates if the invite is a success.
		/// </summary>
		[WireMember(1)]
		public bool isInviteSuccessful { get; private set; }

		/// <summary>
		/// The player's name inviting.
		/// </summary>
		[WireMember(2)]
		public string InvitingPlayer { get; private set; }

		[WireMember(3)]
		private int Unk1 { get; set; }

		//TrinityCore says this is count??
		[WireMember(4)]
		private byte Unk2 { get; set; }

		[WireMember(5)]
		private int Unk3 { get; set; }

		/// <inheritdoc />
		public ServerGroupInviteEvent(bool isInviteSuccessful, [NotNull] string invitingPlayer)
		{
			if(string.IsNullOrWhiteSpace(invitingPlayer)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(invitingPlayer));

			this.isInviteSuccessful = isInviteSuccessful;
			InvitingPlayer = invitingPlayer;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		private ServerGroupInviteEvent()
		{
			
		}
	}
}
