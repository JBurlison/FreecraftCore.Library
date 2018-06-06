using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class NetworkChatWhisperMessageDetails
	{
		/// <summary>
		/// The addressing details containing the
		/// To and From about the message.
		/// </summary>
		[WireMember(1)]
		public MessageAddressingDetails AddressingDetails { get; }

		/// <inheritdoc />
		public NetworkChatWhisperMessageDetails([NotNull] MessageAddressingDetails addressingDetails)
		{
			AddressingDetails = addressingDetails ?? throw new ArgumentNullException(nameof(addressingDetails));
		}

		protected NetworkChatWhisperMessageDetails()
		{
			
		}
	}
}
