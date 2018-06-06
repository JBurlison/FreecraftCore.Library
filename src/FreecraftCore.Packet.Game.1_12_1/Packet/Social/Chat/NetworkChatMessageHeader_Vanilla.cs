using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class NetworkChatMessageHeader_Vanilla
	{
		/// <summary>
		/// Indicates the message type of the chat message.
		/// </summary>
		[WireMember(1)]
		public ChatMessageType_Vanilla MessageType { get; }

		/// <summary>
		/// Indicates the language of the chat message.
		/// </summary>
		[WireMember(2)]
		public ChatLanguage Language { get; }

		/// <inheritdoc />
		public NetworkChatMessageHeader_Vanilla(ChatMessageType_Vanilla messageType, ChatLanguage language)
		{
			MessageType = messageType;
			Language = language;
		}

		protected NetworkChatMessageHeader_Vanilla()
		{

		}
	}
}