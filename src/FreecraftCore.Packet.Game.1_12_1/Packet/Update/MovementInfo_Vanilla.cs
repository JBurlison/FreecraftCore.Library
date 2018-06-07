using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class MovementInfo_Vanilla : IPlayerMovementDatable<MovementFlags_Vanilla>
	{
		/// <summary>
		/// TODO DOC
		/// </summary>
		[WireMember(1)]
		public MovementFlags_Vanilla MoveFlags { get; }

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

		private bool IsOnTransport => MoveFlags.HasFlag(MovementFlags_Vanilla.MOVEFLAG_ONTRANSPORT);

		//TODO: 1.12.1 doesn't have flying?
		private bool HasMovementPitch => MoveFlags.HasFlag(MovementFlags_Vanilla.MOVEFLAG_SWIMMING);

		private bool IsFalling => MoveFlags.HasFlag(MovementFlags_Vanilla.MOVEFLAG_FALLING);

		private bool HasSplineElevation => MoveFlags.HasFlag(MovementFlags_Vanilla.MOVEFLAG_SPLINE_ELEVATION);

		[Optional(nameof(IsOnTransport))]
		[WireMember(6)]
		public TransportationInfo_Vanilla TransportationInformation { get; }

		//This was missing, it is always here on IsOnTransport
		[Optional(nameof(IsOnTransport))]
		[WireMember(7)]
		public int TransportTime { get; }

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
		public MovementInfo_Vanilla(MovementFlags_Vanilla movementFlags, uint timeStamp, Vector3<float> position, float orientation, TransportationInfo_Vanilla transportationInformation, int transportTime, float movePitch, int fallTime, Vector4<float> fallData, float splineElevation)
		{
			MoveFlags = movementFlags;
			TimeStamp = timeStamp;
			Position = position;
			Orientation = orientation;
			TransportationInformation = transportationInformation;
			TransportTime = transportTime;
			MovePitch = movePitch;
			FallTime = fallTime;
			FallData = fallData;
			SplineElevation = splineElevation;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected MovementInfo_Vanilla()
		{

		}
	}
}