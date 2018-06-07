using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.CMSG_MOVE_FALL_RESET)]
	public sealed class CMSG_MOVE_FALL_RESET_Payload_Vanilla : GamePacketPayload, IPlayerMovementPayload<PlayerMoveInfo_Vanilla, MovementFlags_Vanilla>
	{
		/// <summary>
		/// The movement information.
		/// </summary>
		[WireMember(1)]
		public PlayerMoveInfo_Vanilla MoveInfo { get; }

		public CMSG_MOVE_FALL_RESET_Payload_Vanilla([NotNull] PlayerMoveInfo_Vanilla moveInfo)
		{
			MoveInfo = moveInfo ?? throw new ArgumentNullException(nameof(moveInfo));
		}

		protected CMSG_MOVE_FALL_RESET_Payload_Vanilla()
		{

		}
	}
}