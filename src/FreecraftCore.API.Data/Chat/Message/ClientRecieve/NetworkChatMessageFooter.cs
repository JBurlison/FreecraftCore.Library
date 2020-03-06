using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class NetworkChatMessageFooter
	{
		/// <summary>
		/// A null terminated chat string with Length equal to the length of the text
		/// plus one for null terminator.
		/// </summary>
		[WireMember(1)]
		[Encoding(EncodingType.ASCII)]
		[SendSize(SendSizeAttribute.SizeType.Int32)] //WoW sends the size which includes the null terminator; this is likely done for efficiency
		public string MessageText { get; }

		/// <summary>
		/// Indicates the current chat tag.
		/// (Ex. DND or AFK)
		/// </summary>
		[WireMember(2)]
		public ChatStateTag Tag { get; }

		/// <inheritdoc />
		public NetworkChatMessageFooter(string messageText, ChatStateTag tag)
		{
			MessageText = messageText;
			Tag = tag;
		}

		protected NetworkChatMessageFooter()
		{

		}
	}
}
