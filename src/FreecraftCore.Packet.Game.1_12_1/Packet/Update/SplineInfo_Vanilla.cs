using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class SplineInfo_Vanilla
	{
		/// <summary>
		/// Represents all the set spline flags.
		/// </summary>
		[WireMember(1)]
		public SplineFlags_Vanilla SplineFlags { get; }

		public bool HasFinalPoint => SplineFlags.HasFlag(SplineFlags_Vanilla.Final_Point);
		public bool HasFinalTarget => !HasFinalPoint && SplineFlags.HasFlag(SplineFlags_Vanilla.Final_Target);
		public bool HasFinalOrientation => !HasFinalTarget && SplineFlags.HasFlag(SplineFlags_Vanilla.Final_Angle);

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

		//4 fields removed were 3.1+ only

		//TODO: Refactor
		/// <summary>
		/// Length prefixed (int32) collection of waypoints
		/// for the spline.
		/// </summary>
		[SendSize(SendSizeAttribute.SizeType.Int32)]
		[WireMember(12)]
		public Vector3<float>[] WayPoints { get; }

		//Mode does not exist in vanilla

		/// <summary>
		/// The endpoint of the spline.
		/// </summary>
		[WireMember(14)]
		public Vector3<float> SplineEndpoint { get; }

		//TODO: Validation
		/// <inheritdoc />
		public SplineInfo_Vanilla(SplineFlags_Vanilla splineFlags, ObjectGuid finalTarget, float finalOrientation, Vector3<float> finalPoint, int splineTime, int splineFullTime, int splineId, Vector3<float>[] wayPoints, Vector3<float> splineEndpoint)
		{
			SplineFlags = splineFlags;
			FinalTarget = finalTarget;
			FinalOrientation = finalOrientation;
			FinalPoint = finalPoint;
			SplineTime = splineTime;
			SplineFullTime = splineFullTime;
			SplineId = splineId;
			WayPoints = wayPoints;
			SplineEndpoint = splineEndpoint;
		}

		/// <inheritdoc />
		protected SplineInfo_Vanilla()
		{
			
		}
	}
}