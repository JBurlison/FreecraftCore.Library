using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class MessageAddressingDetails<TSenderDataType>
	{
		/// <summary>
		/// The name of the sender.
		/// </summary>
		[Encoding(EncodingType.ASCII)]
		[SendSize(SendSizeAttribute.SizeType.Int32)]
		[WireMember(1)]
		public TSenderDataType SenderInfo { get; }

		//TODO: Why is this sent to the reciever? Shouldn't it be himself?
		/// <summary>
		/// The GUID of the message reciever.
		/// </summary>
		[WireMember(2)]
		public ObjectGuid RecieverGuid { get; }

		/// <inheritdoc />
		public MessageAddressingDetails([CanBeNull] TSenderDataType senderInfo, [NotNull] ObjectGuid recieverGuid)
		{
			SenderInfo = senderInfo;
			RecieverGuid = recieverGuid ?? throw new ArgumentNullException(nameof(recieverGuid));
		}

		protected MessageAddressingDetails()
		{
			
		}
	}
}
