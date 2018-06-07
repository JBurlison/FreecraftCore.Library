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
		public PackedGuid MonsterGuid { get; }

		//Vanilla doesn't have unknown byte

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
		public SplineFlags_Vanilla SplineFlags { get; }

		/// <summary>
		/// The duration of the spline.
		/// </summary>
		[WireMember(8)]
		public int SplineDuration { get; }

		public bool HasLinearPath => !SplineFlags.HasFlag(SplineFlags_Vanilla.Mask_CatmullRom);

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

		//TODO: Additonal ctors
		//TODO: Validate parameters.
		/// <inheritdoc />
		public SMSG_MONSTER_MOVE_Payload_Vanilla(PackedGuid monsterGuid, Vector3<float> initialMovePoint, int splineId, MonsterMoveInfo moveInfo, SplineFlags_Vanilla splineFlags, int splineDuration, Vector3<float>[] optionalCatMulRomSplinePoints, LinearPathMoveInfo optionalLinearPathInformation)
		{
			MonsterGuid = monsterGuid;
			InitialMovePoint = initialMovePoint;
			SplineId = splineId;
			MoveInfo = moveInfo;
			SplineFlags = splineFlags;
			SplineDuration = splineDuration;
			OptionalCatMulRomSplinePoints = optionalCatMulRomSplinePoints;
			OptionalLinearPathInformation = optionalLinearPathInformation;
		}

		protected SMSG_MONSTER_MOVE_Payload_Vanilla()
		{
			
		}
	}
}