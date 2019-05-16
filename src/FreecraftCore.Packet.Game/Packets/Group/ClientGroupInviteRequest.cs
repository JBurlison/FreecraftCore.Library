using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.CMSG_GROUP_INVITE)]
	public sealed class ClientGroupInviteRequest : GamePacketPayload
	{
		//For some reason Blizzard ONLY supports the option to invite based on string
		//I think that's silly
		[WireMember(1)]
		public string PlayerToInvite { get; private set; }

		//TC just discards this.
		[WireMember(2)]
		private int Unk1 { get; set; }

		/// <inheritdoc />
		public ClientGroupInviteRequest([NotNull] string playerToInvite)
		{
			if(string.IsNullOrWhiteSpace(playerToInvite)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(playerToInvite));

			PlayerToInvite = playerToInvite;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		private ClientGroupInviteRequest()
		{
			
		}
	}
}
