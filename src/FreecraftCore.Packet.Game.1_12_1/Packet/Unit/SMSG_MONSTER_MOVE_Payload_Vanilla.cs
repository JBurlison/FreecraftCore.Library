using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_MONSTER_MOVE)]
	public sealed class SMSG_MONSTER_MOVE_Payload_Vanilla : GamePacketPayload
	{
		[WireMember(1)]
		public PackedGuid MonsterGuid { get; internal set; }

		//Vanilla doesn't have unknown byte

		/// <summary>
		/// The initial point of the spline.
		/// </summary>
		[WireMember(3)]
		public Vector3<float> InitialMovePoint { get; internal set; }

		/// <summary>
		/// The id of the spline.
		/// </summary>
		[WireMember(4)]
		public int SplineId { get; internal set; }

		[WireMember(5)]
		public MonsterMoveInfo MoveInfo { get; internal set; }

		/// <summary>
		/// Some "Move" packets are stop moves.
		/// This is will be true when it's a move packet and when it's a stop packet
		/// then it will be false. Stop packets do not have the last half of the packet included
		/// at all.
		/// </summary>
		public bool IsMovePacket => MoveInfo.MoveType != MonsterMoveType.MonsterMoveStop;

		/// <summary>
		/// Optional spline data sent if <see cref="IsMovePacket"/> is true.
		/// Meaning the monster state isn't <see cref="MonsterMoveType.MonsterMoveStop"/>.
		/// </summary>
		[Optional(nameof(IsMovePacket))]
		[WireMember(6)]
		public MonsterSplineInfo_Vanilla OptionalSplineInformation { get; internal set; }

		//TODO: Additonal ctors
		//TODO: Validate parameters.
		/// <inheritdoc />
		public SMSG_MONSTER_MOVE_Payload_Vanilla(PackedGuid monsterGuid, Vector3<float> initialMovePoint, int splineId, MonsterMoveInfo moveInfo, MonsterSplineInfo_Vanilla optionalSplineInformation)
		{
			MonsterGuid = monsterGuid;
			InitialMovePoint = initialMovePoint;
			SplineId = splineId;
			MoveInfo = moveInfo;
			OptionalSplineInformation = optionalSplineInformation;
		}

		public SMSG_MONSTER_MOVE_Payload_Vanilla()
		{
			
		}
	}
}
