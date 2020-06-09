using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.CMSG_GAMEOBJECT_QUERY)]
	public sealed class CMSG_GAMEOBJECT_QUERY_Payload : GamePacketPayload, IQueryRequestPayload
	{
		/// <inheritdoc />
		[WireMember(1)]
		public int QueryId { get; internal set; }

		/// <inheritdoc />
		[WireMember(2)]
		public ObjectGuid QueryGuid { get; internal set; } = ObjectGuid.Empty;

		/// <inheritdoc />
		public CMSG_GAMEOBJECT_QUERY_Payload(int gameObjectId)
		{
			QueryId = gameObjectId;
		}

		protected CMSG_GAMEOBJECT_QUERY_Payload()
		{
			
		}
	}
}
