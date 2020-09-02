using System;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	//TODO: Rewrite this so that we don't need 40 chat packet classes.
	[DefaultChild(typeof(DefaultPlayerChatMessage))]
	[WireDataContractBaseType((int)ChatMessageType.CHAT_MSG_GUILD, typeof(GuildPlayerChatMessage))] //for guild chat
	[WireDataContractBaseType((int)ChatMessageType.CHAT_MSG_CHANNEL, typeof(ChannelPlayerChatMessage))] //for channel messages
	[WireDataContractBaseType((int)ChatMessageType.CHAT_MSG_WHISPER, typeof(WhisperPlayerChatMessage))] //for player whispers
	[WireDataContractBaseType((int)ChatMessageType.CHAT_MSG_SAY, typeof(SayPlayerChatMessage))]
	[WireDataContractBaseType((int)ChatMessageType.CHAT_MSG_AFK, typeof(PlayerAfkChatMessage))]
	[WireDataContract(WireDataContractAttribute.KeyType.Int32, InformationHandlingFlags.DontConsumeRead | InformationHandlingFlags.DontWrite)]
	public abstract class PlayerChatMessage
	{
		//for some reason Blizzard sends uint32s for message type instead of the byte for enum.
		[WireMember(1)]
		internal uint _messageType { get; set; }

		/// <summary>
		/// Indicates the message type of the chat message.
		/// </summary>
		public ChatMessageType MessageType => (ChatMessageType)_messageType;
	
		/// <summary>
		/// Indicates the language of the chat message.
		/// </summary>	
		[WireMember(2)]
		public ChatLanguage Language { get; internal set; }

		protected PlayerChatMessage(ChatMessageType messageType, ChatLanguage language)
		{
			if (!Enum.IsDefined(typeof(ChatMessageType), messageType))
				throw new ArgumentOutOfRangeException(nameof(messageType), "Value should be defined in the ChatMessageType enum.");

			if (!Enum.IsDefined(typeof(ChatLanguage), language))
				throw new ArgumentOutOfRangeException(nameof(language), "Value should be defined in the ChatLanguage enum.");

			_messageType = (uint)messageType;
			Language = language;
		}

		protected PlayerChatMessage()
		{
			
		}
	}
}
