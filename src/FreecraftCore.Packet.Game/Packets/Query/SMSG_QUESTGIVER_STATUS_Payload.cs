using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	//3.3.5 only sends a byte for the state unlike 1.12.1's 4 bytes
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_QUESTGIVER_STATUS)]
	public sealed class SMSG_QUESTGIVER_STATUS_Payload : GamePacketPayload
	{
		/// <summary>
		/// The ID of the quest query.
		/// </summary>
		[WireMember(1)]
		public ObjectGuid QueryId { get; }

		[WireMember(2)]
		public QuestGiverStatus Status { get; }

		/// <inheritdoc />
		public SMSG_QUESTGIVER_STATUS_Payload([NotNull] ObjectGuid queryId, QuestGiverStatus status)
		{
			QueryId = queryId ?? throw new ArgumentNullException(nameof(queryId));
			Status = status;
		}

		protected SMSG_QUESTGIVER_STATUS_Payload()
		{
			
		}
	}
}
