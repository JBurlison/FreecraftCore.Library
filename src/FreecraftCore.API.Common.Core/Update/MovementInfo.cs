using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class MovementInfo
	{
		/// <summary>
		/// TODO DOC
		/// </summary>
		[WireMember(1)]
		public MovementFlag MovementFlags { get; }

		//ClientVersion.AddedInVersion(ClientVersionBuild.V3_0_2_9056) previous to 3.0 it was a byte.
		[WireMember(2)]
		public MovementFlagExtra ExtraFlags { get; }

		//TODO: Support packed date time? Or is this milliseconds?
		[WireMember(3)]
		public uint TimeStamp { get; }

		/// <summary>
		/// The Vector3 x,y,z position.
		/// </summary>
		[WireMember(4)]
		public Vector3<float> Position { get; }

		/// <summary>
		/// Probably Y axis rotation.
		/// </summary>
		[WireMember(5)]
		public float Orientation { get; }

		private bool IsOnTransport => MovementFlags.HasFlag(MovementFlag.MOVEMENTFLAG_ONTRANSPORT);

		private bool HasTransportationTime => IsOnTransport && ExtraFlags.HasFlag(MovementFlagExtra.InterpolateMove);

		private bool HasMovementPitch => MovementFlags.HasFlag(MovementFlag.MOVEMENTFLAG_SWIMMING | MovementFlag.MOVEMENTFLAG_FLYING)
			|| ExtraFlags.HasFlag(MovementFlagExtra.AlwaysAllowPitching);

		private bool IsFalling => MovementFlags.HasFlag(MovementFlag.MOVEMENTFLAG_FALLING);

		private bool HasSplineElevation => MovementFlags.HasFlag(MovementFlag.MOVEMENTFLAG_SPLINE_ELEVATION);

		[Optional(nameof(IsOnTransport))]
		[WireMember(6)]
		public TransportationInfo TransportationInformation { get; }

		[Optional(nameof(HasTransportationTime))]
		[WireMember(7)]
		public int TransportationTime { get; }

		//AKA: Swim Pitch
		[Optional(nameof(HasMovementPitch))]
		[WireMember(8)]
		public float MovePitch { get; }

		//Always read for some reason
		[WireMember(9)]
		public int FallTime { get; }

		//TODO: Refactor/encapsulate
		//Optional fall data
		[Optional(nameof(IsFalling))]
		[WireMember(10)]
		public Vector4<float> FallData { get; }

		//This is a hack though?
		[Optional(nameof(HasSplineElevation))]
		[WireMember(11)]
		public float SplineElevation { get; }

		//TODO: Parameter validation
		/// <inheritdoc />
		public MovementInfo(MovementFlag movementFlags, MovementFlagExtra extraFlags, uint timeStamp, Vector3<float> position, float orientation, TransportationInfo transportationInformation, int transportationTime, float movePitch, int fallTime, Vector4<float> fallData, float splineElevation)
		{
			MovementFlags = movementFlags;
			ExtraFlags = extraFlags;
			TimeStamp = timeStamp;
			Position = position;
			Orientation = orientation;
			TransportationInformation = transportationInformation;
			TransportationTime = transportationTime;
			MovePitch = movePitch;
			FallTime = fallTime;
			FallData = fallData;
			SplineElevation = splineElevation;
		}
		
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected MovementInfo()
		{
			
		}
	}
}