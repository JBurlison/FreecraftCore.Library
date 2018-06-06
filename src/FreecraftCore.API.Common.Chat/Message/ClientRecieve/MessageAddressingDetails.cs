using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class MessageAddressingDetails
	{
		/// <summary>
		/// The name of the sender.
		/// </summary>
		[Encoding(EncodingType.ASCII)]
		[SendSize(SendSizeAttribute.SizeType.Int32)]
		[WireMember(1)]
		public string SenderName { get; }

		//TODO: Why is this sent to the reciever? Shouldn't it be himself?
		/// <summary>
		/// The GUID of the message reciever.
		/// </summary>
		[WireMember(2)]
		public ObjectGuid RecieverGuid { get; }

		/// <inheritdoc />
		public MessageAddressingDetails([NotNull] string senderName, [NotNull] ObjectGuid recieverGuid)
		{
			SenderName = senderName ?? throw new ArgumentNullException(nameof(senderName));
			RecieverGuid = recieverGuid ?? throw new ArgumentNullException(nameof(recieverGuid));
		}

		protected MessageAddressingDetails()
		{
			
		}
	}
}
