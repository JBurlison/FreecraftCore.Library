using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_MONSTER_MOVE)]
	public sealed class SMSG_MONSTER_MOVE_Payload : GamePacketPayload
	{
		[WireMember(1)]
		public PackedGuid MonsterGuid { get; }

		[WireMember(2)]
		public byte Unk1 { get; } //TC says: sets/unsets MOVEMENTFLAG2_UNK7 (0x40)

		/// <summary>
		/// The initial point of the spline.
		/// </summary>
		[WireMember(3)]
		public Vector3<float> InitialMovePoint { get; }

		/// <summary>
		/// The id of the spline.
		/// </summary>
		[WireMember(4)]
		public int SplineId { get; }

		/// <summary>
		/// The movement information for the monster.
		/// If the <see cref="MonsterMoveType"/> is set to <see cref="MonsterMoveType.MonsterMoveStop"/>
		/// is set then it will NOT contain any information after the byte enum.
		/// The rest of the packet will be empty.
		/// </summary>
		[WireMember(5)]
		public MonsterMoveInfo MoveInfo { get; }

		/// <summary>
		/// Some "Move" packets are stop moves.
		/// This is will be true when it's a move packet and when it's a stop packet
		/// then it will be false. Stop packets do not have the last half of the packet included
		/// at all.
		/// </summary>
		public bool IsMovePacket => MoveInfo.MoveType != MonsterMoveType.MonsterMoveStop;

		/// <summary>
		/// Default value (or stop value) is <see cref="SplineMoveFlags.None"/>
		/// </summary>
		[Optional(nameof(IsMovePacket))]
		[WireMember(6)]
		public SplineMoveFlags SplineFlags { get; } = SplineMoveFlags.None;

		/// <summary>
		/// Indicates if the move information has animation
		/// data <see cref="OptionalAnimationInformation"/>
		/// </summary>
		public bool HasAnimationInformation => IsMovePacket && SplineFlags.HasFlag(SplineMoveFlags.Animation);

		[Optional(nameof(HasAnimationInformation))]
		[WireMember(7)]
		public AnimationInfo OptionalAnimationInformation { get; }

		/// <summary>
		/// The duration of the spline.
		/// </summary>
		[Optional(nameof(IsMovePacket))]
		[WireMember(8)]
		public int SplineDuration { get; }

		/// <summary>
		/// Indicates if the move information has parabolic spline information.
		/// </summary>
		public bool HasParabolicSplineInfo => IsMovePacket && SplineFlags.HasFlag(SplineMoveFlags.Parabolic);

		[Optional(nameof(HasParabolicSplineInfo))]
		[WireMember(9)]
		public ParabolicMoveInfo OptionalParabolicSplineInformation { get; }

		public bool HasLinearPath => IsMovePacket && !HasCatMulRomSpline;

		/// <summary>
		/// Indicates if the optional cyclic catmulrom spline path information
		/// is in the packet.
		/// </summary>
		public bool HasCatMulRomSpline => IsMovePacket && (SplineFlags & SplineMoveFlags.Mask_CatmullRom) != 0;

		[SendSize(SendSizeAttribute.SizeType.Int32)] //we have to add 1 to the size, it's what TC does
		[Optional(nameof(HasCatMulRomSpline))]
		[WireMember(10)]
		public Vector3<float>[] OptionalCatMulRomSplinePoints { get; }

		[Optional(nameof(HasLinearPath))]
		[WireMember(11)]
		public LinearPathMoveInfo OptionalLinearPathInformation { get; }

		//TODO: Additional ctors
		//TODO: Validate parameters.
		/// <inheritdoc />
		public SMSG_MONSTER_MOVE_Payload(PackedGuid monsterGuid, byte unk1, Vector3<float> initialMovePoint, int splineId, MonsterMoveInfo moveInfo, SplineMoveFlags splineFlags, AnimationInfo optionalAnimationInformation, int splineDuration, ParabolicMoveInfo optionalParabolicSplineInformation, Vector3<float>[] optionalCatMulRomSplinePoints, LinearPathMoveInfo optionalLinearPathInformation)
		{
			MonsterGuid = monsterGuid;
			Unk1 = unk1;
			InitialMovePoint = initialMovePoint;
			SplineId = splineId;
			MoveInfo = moveInfo;
			SplineFlags = splineFlags;
			OptionalAnimationInformation = optionalAnimationInformation;
			SplineDuration = splineDuration;
			OptionalParabolicSplineInformation = optionalParabolicSplineInformation;
			OptionalCatMulRomSplinePoints = optionalCatMulRomSplinePoints;
			OptionalLinearPathInformation = optionalLinearPathInformation;
		}

		/// <inheritdoc />
		protected SMSG_MONSTER_MOVE_Payload()
		{
			
		}
	}
}
