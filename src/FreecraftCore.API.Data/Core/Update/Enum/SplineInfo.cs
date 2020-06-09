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
		public SplineMoveFlags SplineFlags { get; internal set; }

		public bool HasFinalOrientation => SplineFlags.HasFlag(SplineMoveFlags.Final_Angle);
		public bool HasFinalTarget => !HasFinalOrientation && SplineFlags.HasFlag(SplineMoveFlags.Final_Target);
		public bool HasFinalPoint => !HasFinalTarget && SplineFlags.HasFlag(SplineMoveFlags.Final_Point);

		/// <summary>
		/// Optional: Exists if <see cref="SplineFlag.FinalTarget"/> is set.
		/// </summary>
		[Optional(nameof(HasFinalTarget))]
		[WireMember(2)]
		public ObjectGuid FinalTarget { get; internal set; }

		/// <summary>
		/// Optional: Exists if <see cref="SplineFlag.FinalOrientation"/> is set.
		/// </summary>
		[Optional(nameof(HasFinalOrientation))]
		[WireMember(3)]
		public float FinalOrientation { get; internal set; }

		/// <summary>
		/// Optional: Exists if <see cref="SplineFlag.FinalPoint"/> is set.
		/// </summary>
		[Optional(nameof(HasFinalPoint))]
		[WireMember(4)]
		public Vector3<float> FinalPoint { get; internal set; }

		/// <summary>
		/// Represents the milliseconds of time that has passed since
		/// the spline began.
		/// </summary>
		[WireMember(5)]
		public int SplineTime { get; internal set; }

		/// <summary>
		/// Represents the full milliseconds duration of the spline.
		/// </summary>
		[WireMember(6)]
		public int SplineFullTime { get; internal set; }

		[WireMember(7)]
		public int SplineId { get; internal set; }

		//ClientVersion.AddedInVersion(ClientVersionBuild.V3_1_0_9767) Next 4 fields only exist post 3.1
		[WireMember(8)]
		public float SplineDurationMultiplier { get; internal set; }

		[WireMember(9)]
		public float SplineDurationMultiplierNext { get; internal set; }

		[WireMember(10)]
		public float SplineVerticalAcceleration { get; internal set; }

		[WireMember(11)]
		public int SplineStartTime { get; internal set; }

		//TODO: Refactor
		/// <summary>
		/// Length prefixed (int32) collection of waypoints
		/// for the spline.
		/// </summary>
		[SendSize(SendSizeAttribute.SizeType.Int32)]
		[WireMember(12)]
		public Vector3<float>[] WayPoints { get; internal set; }

		//ClientVersion.AddedInVersion(ClientVersionBuild.V3_1_0_9767) added after 3.1
		/// <summary>
		/// The spline mode.
		/// </summary>
		[WireMember(13)]
		public SplineMode Mode { get; internal set; }

		/// <summary>
		/// The endpoint of the spline.
		/// </summary>
		[WireMember(14)]
		public Vector3<float> SplineEndpoint { get; internal set; }

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
