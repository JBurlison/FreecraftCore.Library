using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.CMSG_MOVE_FALL_RESET)]
	public sealed class CMSG_MOVE_FALL_RESET_Payload : GamePacketPayload, IPlayerMovementPayload<PlayerMoveInfo, MovementFlag>
	{
		/// <summary>
		/// The movement information.
		/// </summary>
		[WireMember(1)]
		public PlayerMoveInfo MoveInfo { get; }

		public CMSG_MOVE_FALL_RESET_Payload([NotNull] PlayerMoveInfo moveInfo)
		{
			MoveInfo = moveInfo ?? throw new ArgumentNullException(nameof(moveInfo));
		}

		protected CMSG_MOVE_FALL_RESET_Payload()
		{

		}
	}
}