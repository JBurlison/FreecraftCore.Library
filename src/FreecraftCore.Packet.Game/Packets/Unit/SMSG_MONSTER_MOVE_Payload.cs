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

		[WireMember(5)]
		public MonsterMoveInfo MoveInfo { get; }

		[WireMember(6)]
		public SplineMoveFlags SplineFlags { get; }
		
		/// <summary>
		/// Indicates if the move information has animation
		/// data <see cref="OptionalAnimationInformation"/>
		/// </summary>
		public bool HasAnimationInformation => SplineFlags.HasFlag(SplineMoveFlags.Animation);

		[Optional(nameof(HasAnimationInformation))]
		[WireMember(7)]
		public AnimationInfo OptionalAnimationInformation { get; }

		/// <summary>
		/// The duration of the spline.
		/// </summary>
		[WireMember(8)]
		public int SplineDuration { get; }

		/// <summary>
		/// Indicates if the move information has parabolic spline information.
		/// </summary>
		public bool HasParabolicSplineInfo => SplineFlags.HasFlag(SplineMoveFlags.Parabolic);

		[Optional(nameof(HasParabolicSplineInfo))]
		[WireMember(9)]
		public ParabolicMoveInfo OptionalParabolicSplineInformation { get; }

		public bool HasLinearPath => !SplineFlags.HasFlag(SplineMoveFlags.Mask_CatmullRom);

		/// <summary>
		/// Indicates if the optional cyclic catmulrom spline path information
		/// is in the packet.
		/// </summary>
		public bool HasCatMulRomSpline => !HasLinearPath;

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

		protected SMSG_MONSTER_MOVE_Payload()
		{
			
		}
	}
}
