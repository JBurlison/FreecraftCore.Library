using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	//TODO: Support BG and Achievement messages
	/// <summary>
	/// Represents a chat message payload from 3.3.5
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_MESSAGECHAT)]
	[ProtocolGrouping(ProtocolCode.Game)] //TODO: Change this protocol to something more specific
	public class SMSG_MESSAGECHAT_Payload_Vanilla : GamePacketPayload
	{
		/// <summary>
		/// The header details of the message.
		/// </summary>
		[WireMember(1)]
		public NetworkChatMessageHeader_Vanilla MessageHeader { get; }

		/// <summary>
		/// Indicates if it is a creature message and
		/// if the <see cref="CreatureSpecialMessageDetails"/> is set.
		/// </summary>
		public bool IsCreatureSpecialMessage
		{
			get
			{
				switch(MessageHeader.MessageType)
				{
					case ChatMessageType_Vanilla.CHAT_MSG_MONSTER_WHISPER:
					case ChatMessageType_Vanilla.CHAT_MSG_RAID_BOSS_WHISPER:
					case ChatMessageType_Vanilla.CHAT_MSG_RAID_BOSS_EMOTE:
					case ChatMessageType_Vanilla.CHAT_MSG_MONSTER_EMOTE:
						return true;
					default:
						return false;
				}
			}
		}

		/// <summary>
		/// Indicates if it is a creature message and
		/// if the <see cref="CreatureRegularMessageDetails"/> is set.
		/// </summary>
		public bool IsCreatureRegularMessage
		{
			get
			{
				switch(MessageHeader.MessageType)
				{
					case ChatMessageType_Vanilla.CHAT_MSG_MONSTER_SAY:
					case ChatMessageType_Vanilla.CHAT_MSG_MONSTER_YELL:
						return true;
					default:
						return false;
				}
			}
		}

		/// <summary>
		/// Indicates if it s a chat channel message
		/// and if <see cref="ChannelMessageDetails"/>
		/// is set.
		/// </summary>
		public bool IsChatChannelMessage
		{
			get
			{
				switch(MessageHeader.MessageType)
				{
					case ChatMessageType_Vanilla.CHAT_MSG_CHANNEL:
						return true;
					default:
						return false;
				}
			}
		}

		/// <summary>
		/// Indicates if its a regular chat message
		/// and if <see cref="RegularMessageDetails"/>
		/// is set.
		/// </summary>
		public bool IsRegularChatMessage
		{
			get
			{
				switch(MessageHeader.MessageType)
				{
					case ChatMessageType_Vanilla.CHAT_MSG_SAY:
					case ChatMessageType_Vanilla.CHAT_MSG_PARTY:
					case ChatMessageType_Vanilla.CHAT_MSG_YELL:
						return true;
					default:
						return false;
				}
			}
		}

		/// <summary>
		/// Indicates that the message is a default chat message
		/// meaning <see cref="DefaultMessageDetails"/> is set.
		/// </summary>
		public bool IsDefaultChatMessage => !IsChatChannelMessage &&
			!IsCreatureSpecialMessage;

		/// <summary>
		/// The creature message details.
		/// </summary>
		[CanBeNull]
		[Optional(nameof(IsCreatureSpecialMessage))]
		[WireMember(7)]
		public MessageAddressingDetails<string> CreatureSpecialMessageDetails { get; }

		/// <summary>
		/// The creature regular message details.
		/// </summary>
		[CanBeNull]
		[Optional(nameof(IsCreatureRegularMessage))]
		[WireMember(8)]
		public NetworkChatCreatureRegularMessageDetails_Vanilla CreatureRegularMessageDetails { get; }

		/// <summary>
		/// The channel message details.
		/// </summary>
		[CanBeNull]
		[Optional(nameof(IsChatChannelMessage))]
		[WireMember(8)]
		public NetworkChatChannelMessageDetails_Vanilla ChannelMessageDetails { get; }

		/// <summary>
		/// A regular message details.
		/// </summary>
		[CanBeNull]
		[Optional(nameof(IsRegularChatMessage))]
		[WireMember(9)]
		public MessageAddressingDetails<ObjectGuid> RegularMessageDetails { get; }

		[CanBeNull]
		[Optional(nameof(IsDefaultChatMessage))]
		[WireMember(9)]
		public NetworkChatDefaultMessageDetails DefaultMessageDetails { get; }

		/// <summary>
		/// These details are sent in all messages.
		/// </summary>
		[WireMember(50)]
		public NetworkChatMessageFooter MessageFooter { get; }


		/// <inheritdoc />
		public SMSG_MESSAGECHAT_Payload_Vanilla([NotNull] NetworkChatMessageHeader_Vanilla messageHeader, [NotNull] NetworkChatMessageFooter messageFooter, [NotNull] NetworkChatDefaultMessageDetails defaultMessageDetails)
		{
			MessageHeader = messageHeader ?? throw new ArgumentNullException(nameof(messageHeader));
			DefaultMessageDetails = defaultMessageDetails ?? throw new ArgumentNullException(nameof(defaultMessageDetails));
			MessageFooter = messageFooter ?? throw new ArgumentNullException(nameof(messageFooter));
		}

		/// <inheritdoc />
		public SMSG_MESSAGECHAT_Payload_Vanilla([NotNull] NetworkChatMessageHeader_Vanilla messageHeader, [NotNull] NetworkChatMessageFooter messageFooter, [NotNull] MessageAddressingDetails<ObjectGuid> regularMessageDetails)
		{
			MessageHeader = messageHeader ?? throw new ArgumentNullException(nameof(messageHeader));
			RegularMessageDetails = regularMessageDetails ?? throw new ArgumentNullException(nameof(regularMessageDetails));
			MessageFooter = messageFooter ?? throw new ArgumentNullException(nameof(messageFooter));
		}

		/// <inheritdoc />
		public SMSG_MESSAGECHAT_Payload_Vanilla([NotNull] NetworkChatMessageHeader_Vanilla messageHeader, [NotNull] NetworkChatMessageFooter messageFooter, [NotNull] NetworkChatChannelMessageDetails_Vanilla channelMessageDetails)
		{
			MessageHeader = messageHeader ?? throw new ArgumentNullException(nameof(messageHeader));
			ChannelMessageDetails = channelMessageDetails ?? throw new ArgumentNullException(nameof(channelMessageDetails));
			MessageFooter = messageFooter ?? throw new ArgumentNullException(nameof(messageFooter));
		}

		/// <inheritdoc />
		public SMSG_MESSAGECHAT_Payload_Vanilla([NotNull] NetworkChatMessageHeader_Vanilla messageHeader, [NotNull] NetworkChatMessageFooter messageFooter, [NotNull] NetworkChatCreatureRegularMessageDetails_Vanilla creatureRegularMessageDetails)
		{
			MessageHeader = messageHeader ?? throw new ArgumentNullException(nameof(messageHeader));
			CreatureRegularMessageDetails = creatureRegularMessageDetails ?? throw new ArgumentNullException(nameof(creatureRegularMessageDetails));
			MessageFooter = messageFooter ?? throw new ArgumentNullException(nameof(messageFooter));
		}

		/// <inheritdoc />
		public SMSG_MESSAGECHAT_Payload_Vanilla([NotNull] NetworkChatMessageHeader_Vanilla messageHeader, [NotNull] NetworkChatMessageFooter messageFooter, [NotNull] MessageAddressingDetails<string> creatureSpecialMessageDetails)
		{
			MessageHeader = messageHeader ?? throw new ArgumentNullException(nameof(messageHeader));
			CreatureSpecialMessageDetails = creatureSpecialMessageDetails ?? throw new ArgumentNullException(nameof(creatureSpecialMessageDetails));
			MessageFooter = messageFooter ?? throw new ArgumentNullException(nameof(messageFooter));
		}

		protected SMSG_MESSAGECHAT_Payload_Vanilla()
		{
			
		}
	}
}
