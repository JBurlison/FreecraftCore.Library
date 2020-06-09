using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_DESTROY_OBJECT)]
	public sealed class SMSG_DESTROY_OBJECT_Payload_Vanilla : GamePacketPayload
	{
		[WireMember(1)]
		public ObjectGuid DestroyedObject { get; internal set; }

		//1.12.1 does not send the bool for OnDeath

		/// <inheritdoc />
		public SMSG_DESTROY_OBJECT_Payload_Vanilla([NotNull] ObjectGuid destroyedObject)
		{
			DestroyedObject = destroyedObject ?? throw new ArgumentNullException(nameof(destroyedObject));
		}

		protected SMSG_DESTROY_OBJECT_Payload_Vanilla()
		{

		}
	}
}
