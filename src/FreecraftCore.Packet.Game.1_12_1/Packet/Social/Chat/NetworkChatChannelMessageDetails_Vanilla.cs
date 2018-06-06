using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class NetworkChatChannelMessageDetails_Vanilla
	{
		/// <summary>
		/// Null terminate channel name.
		/// </summary>
		[Encoding(EncodingType.ASCII)]
		[WireMember(1)]
		public string ChannelName { get; }

		//TODO: Create enum
		/// <summary>
		/// The player's rank in the channel
		/// </summary>
		[WireMember(2)]
		public int PlayerRank { get; }

		//TODO: Why is this reciever?
		[WireMember(3)]
		public ObjectGuid RecieverGuid { get; }

		/// <inheritdoc />
		public NetworkChatChannelMessageDetails_Vanilla([NotNull] string channelName, [NotNull] ObjectGuid recieverGuid, int playerRank)
		{
			ChannelName = channelName ?? throw new ArgumentNullException(nameof(channelName));
			RecieverGuid = recieverGuid ?? throw new ArgumentNullException(nameof(recieverGuid));
			PlayerRank = playerRank;
		}

		protected NetworkChatChannelMessageDetails_Vanilla()
		{

		}
	}
}