using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Base contract for network messages.
	/// </summary>
	public interface INetworkChatMessage
	{
		/// <summary>
		/// Indicates the message type of the chat message.
		/// </summary>
		ChatMessageType MessageType { get; }

		/// <summary>
		/// Indicates the language of the chat message.
		/// </summary>
		ChatLanguage Language { get; }
	}
}
