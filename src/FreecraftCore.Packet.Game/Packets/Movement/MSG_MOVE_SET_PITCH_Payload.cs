using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.MSG_MOVE_SET_PITCH)]
	public sealed class MSG_MOVE_SET_PITCH_Payload : GamePacketPayload
	{
		/// <summary>
		/// The movement information.
		/// </summary>
		[WireMember(1)]
		public PlayerMoveInfo MoveInfo { get; }

		public MSG_MOVE_SET_PITCH_Payload([NotNull] PlayerMoveInfo moveInfo)
		{
			MoveInfo = moveInfo ?? throw new ArgumentNullException(nameof(moveInfo));
		}

		protected MSG_MOVE_SET_PITCH_Payload()
		{

		}
	}
}