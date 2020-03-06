using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class SplineInfo
	{
		/// <summary>
		/// Represents all the set spline flags.
		/// </summary>
		[WireMember(1)]
		public SplineMoveFlags SplineFlags { get; }

		public bool HasFinalOrientation => SplineFlags.HasFlag(SplineMoveFlags.Final_Angle);
		public bool HasFinalTarget => !HasFinalOrientation && SplineFlags.HasFlag(SplineMoveFlags.Final_Target);
		public bool HasFinalPoint => !HasFinalTarget && SplineFlags.HasFlag(SplineMoveFlags.Final_Point);

		/// <summary>
		/// Optional: Exists if <see cref="SplineFlag.FinalTarget"/> is set.
		/// </summary>
		[Optional(nameof(HasFinalTarget))]
		[WireMember(2)]
		public ObjectGuid FinalTarget { get; }

		/// <summary>
		/// Optional: Exists if <see cref="SplineFlag.FinalOrientation"/> is set.
		/// </summary>
		[Optional(nameof(HasFinalOrientation))]
		[WireMember(3)]
		public float FinalOrientation { get; }

		/// <summary>
		/// Optional: Exists if <see cref="SplineFlag.FinalPoint"/> is set.
		/// </summary>
		[Optional(nameof(HasFinalPoint))]
		[WireMember(4)]
		public Vector3<float> FinalPoint { get; }

		//TODO: What are these?
		//Always has these next 3 fields
		[WireMember(5)]
		public int SplineTime { get; }

		[WireMember(6)]
		public int SplineFullTime { get; }

		[WireMember(7)]
		public int SplineId { get; }

		//ClientVersion.AddedInVersion(ClientVersionBuild.V3_1_0_9767) Next 4 fields only exist post 3.1
		[WireMember(8)]
		public float SplineDurationMultiplier { get; }

		[WireMember(9)]
		public float SplineDurationMultiplierNext { get; }

		[WireMember(10)]
		public float SplineVerticalAcceleration { get; }

		[WireMember(11)]
		public int SplineStartTime { get; }

		//TODO: Refactor
		/// <summary>
		/// Length prefixed (int32) collection of waypoints
		/// for the spline.
		/// </summary>
		[SendSize(SendSizeAttribute.SizeType.Int32)]
		[WireMember(12)]
		public Vector3<float>[] WayPoints { get; }

		//ClientVersion.AddedInVersion(ClientVersionBuild.V3_1_0_9767) added after 3.1
		/// <summary>
		/// The spline mode.
		/// </summary>
		[WireMember(13)]
		public SplineMode Mode { get; }

		/// <summary>
		/// The endpoint of the spline.
		/// </summary>
		[WireMember(14)]
		public Vector3<float> SplineEndpoint { get; }

		//TODO: Validation
		/// <inheritdoc />
		public SplineInfo(SplineMoveFlags splineFlags, ObjectGuid finalTarget, float finalOrientation, Vector3<float> finalPoint, int splineTime, int splineFullTime, int splineId, float splineDurationMultiplier, float splineDurationMultiplierNext, float splineVerticalAcceleration, int splineStartTime, Vector3<float>[] wayPoints, SplineMode mode, Vector3<float> splineEndpoint)
		{
			SplineFlags = splineFlags;
			FinalTarget = finalTarget;
			FinalOrientation = finalOrientation;
			FinalPoint = finalPoint;
			SplineTime = splineTime;
			SplineFullTime = splineFullTime;
			SplineId = splineId;
			SplineDurationMultiplier = splineDurationMultiplier;
			SplineDurationMultiplierNext = splineDurationMultiplierNext;
			SplineVerticalAcceleration = splineVerticalAcceleration;
			SplineStartTime = splineStartTime;
			WayPoints = wayPoints;
			Mode = mode;
			SplineEndpoint = splineEndpoint;
		}

		protected SplineInfo()
		{
			
		}
	}
}