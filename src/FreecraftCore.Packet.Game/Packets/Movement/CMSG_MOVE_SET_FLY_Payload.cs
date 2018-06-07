using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.CMSG_MOVE_SET_FLY)]
	public sealed class CMSG_MOVE_SET_FLY_Payload : GamePacketPayload
	{
		/// <summary>
		/// The movement information.
		/// </summary>
		[WireMember(1)]
		public PlayerMoveInfo MoveInfo { get; }

		public CMSG_MOVE_SET_FLY_Payload([NotNull] PlayerMoveInfo moveInfo)
		{
			MoveInfo = moveInfo ?? throw new ArgumentNullException(nameof(moveInfo));
		}

		protected CMSG_MOVE_SET_FLY_Payload()
		{

		}
	}
}