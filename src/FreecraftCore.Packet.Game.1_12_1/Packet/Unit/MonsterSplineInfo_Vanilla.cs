using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class MonsterSplineInfo_Vanilla
	{
		[WireMember(6)]
		public SplineMoveFlags_Vanilla SplineFlags { get; }

		/// <summary>
		/// The duration of the spline.
		/// </summary>
		[WireMember(8)]
		public int SplineDuration { get; }

		public bool HasLinearPath => !HasCatMulRomSpline;

		/// <summary>
		/// Indicates if the optional cyclic catmulrom spline path information
		/// is in the packet.
		/// </summary>
		public bool HasCatMulRomSpline => (SplineFlags & SplineMoveFlags_Vanilla.Mask_CatmullRom) != 0;

		[SendSize(SendSizeAttribute.SizeType.Int32)]
		[Optional(nameof(HasCatMulRomSpline))]
		[WireMember(10)]
		public Vector3<float>[] OptionalCatMulRomSplinePoints { get; }

		[Optional(nameof(HasLinearPath))]
		[WireMember(11)]
		public LinearPathMoveInfo OptionalLinearPathInformation { get; }

		/// <inheritdoc />
		public MonsterSplineInfo_Vanilla(SplineMoveFlags_Vanilla splineFlags, int splineDuration, Vector3<float>[] optionalCatMulRomSplinePoints, LinearPathMoveInfo optionalLinearPathInformation)
		{
			SplineFlags = splineFlags;
			SplineDuration = splineDuration;
			OptionalCatMulRomSplinePoints = optionalCatMulRomSplinePoints;
			OptionalLinearPathInformation = optionalLinearPathInformation;
		}

		public MonsterSplineInfo_Vanilla()
		{
			
		}
	}
}
