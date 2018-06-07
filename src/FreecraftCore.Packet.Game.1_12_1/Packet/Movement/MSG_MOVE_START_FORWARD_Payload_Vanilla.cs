using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.MSG_MOVE_START_FORWARD)]
	public sealed class MSG_MOVE_START_FORWARD_Payload_Vanilla : GamePacketPayload, IPlayerMovementPayload<PlayerMoveInfo_Vanilla, MovementFlags_Vanilla>
	{
		/// <summary>
		/// The movement information.
		/// </summary>
		[WireMember(1)]
		public PlayerMoveInfo_Vanilla MoveInfo { get; }

		public MSG_MOVE_START_FORWARD_Payload_Vanilla([NotNull] PlayerMoveInfo_Vanilla moveInfo)
		{
			MoveInfo = moveInfo ?? throw new ArgumentNullException(nameof(moveInfo));
		}

		protected MSG_MOVE_START_FORWARD_Payload_Vanilla()
		{
			
		}
	}
}
