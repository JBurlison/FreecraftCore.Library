using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class NetworkChatCreatureRegularMessageDetails_Vanilla
	{
		/// <summary>
		/// The GUID of the sender.
		/// </summary>
		[WireMember(1)]
		public ObjectGuid SenderGuid { get; internal set; }

		/// <summary>
		/// The addressing details containing the
		/// To and From about the message.
		/// </summary>
		[WireMember(2)]
		public MessageAddressingDetails<string> AddressingDetails { get; internal set; }

		/// <inheritdoc />
		public NetworkChatCreatureRegularMessageDetails_Vanilla([NotNull] ObjectGuid senderGuid, [NotNull] MessageAddressingDetails<string> addressingDetails)
		{
			AddressingDetails = addressingDetails ?? throw new ArgumentNullException(nameof(addressingDetails));
			SenderGuid = senderGuid ?? throw new ArgumentNullException(nameof(senderGuid));
		}

		protected NetworkChatCreatureRegularMessageDetails_Vanilla()
		{

		}
	}
}
