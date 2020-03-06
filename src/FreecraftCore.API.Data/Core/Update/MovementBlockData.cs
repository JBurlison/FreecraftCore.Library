using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class MovementBlockData
	{
		/// <summary>
		/// The movement update flags.
		/// </summary>
		[WireMember(2)]
		public ObjectUpdateFlags UpdateFlags { get; }

		//MovementInfo is only sent if the unit is living.
		public bool IsLiving => UpdateFlags.HasFlag(ObjectUpdateFlags.UPDATEFLAG_LIVING);

		public bool HasSplineData => IsLiving && MoveInfo.MoveFlags.HasFlag(MovementFlag.MOVEMENTFLAG_SPLINE_ENABLED);

		public bool IsDead => !IsLiving;

		[Optional(nameof(IsLiving))]
		[WireMember(3)]
		public MovementInfo MoveInfo { get; }

		//Only sent if we're alive
		/// <summary>
		/// Sent if we're alive. Array of <see cref="SpeedType"/>-based speeds.
		/// </summary>
		[Optional(nameof(IsLiving))]
		[KnownSize(9)] //length of SpeedType enum
		[WireMember(4)]
		public float[] MovementSpeeds { get; } //see SpeedType to understand index.

		//Now there is some optional spline data if we're alive. Too. Great...
		[Optional(nameof(HasSplineData))]
		[WireMember(5)]
		public SplineInfo SplineInformation { get; }

		private bool HasUpdatePosition => UpdateFlags.HasFlag(ObjectUpdateFlags.UPDATEFLAG_POSITION);

		//The following data requires that we're not living.
		private bool HasCorpseLocation => IsDead && HasUpdatePosition; //TODO: WPP says this is GOPosition

		private bool IsStationaryObject => IsDead && !HasUpdatePosition && UpdateFlags.HasFlag(ObjectUpdateFlags.UPDATEFLAG_STATIONARY_POSITION);

		[Optional(nameof(HasCorpseLocation))]
		[WireMember(6)]
		public CorpseInfo DeadMovementInformation { get; }

		[Optional(nameof(IsStationaryObject))]
		[WireMember(7)]
		public StationaryMovementInfo StationaryObjectMovementInformation { get; }

		public bool HasUnknown1 => UpdateFlags.HasFlag(ObjectUpdateFlags.UPDATEFLAG_UNKNOWN);

		public bool HasLowGuid => UpdateFlags.HasFlag(ObjectUpdateFlags.UPDATEFLAG_LOWGUID);

		public bool IsAttackingTarget => UpdateFlags.HasFlag(ObjectUpdateFlags.UPDATEFLAG_HAS_TARGET);

		public bool HasTransport => UpdateFlags.HasFlag(ObjectUpdateFlags.UPDATEFLAG_TRANSPORT);

		public bool IsInVehicle => UpdateFlags.HasFlag(ObjectUpdateFlags.UPDATEFLAG_VEHICLE);

		//ClientVersion.RemovedInVersion(ClientVersionBuild.V4_2_2_14545)
		[Optional(nameof(HasUnknown1))]
		[WireMember(8)]
		public int Unk1 { get; }

		[Optional(nameof(HasLowGuid))]
		[WireMember(9)]
		public uint LowGuid { get; }

		[Optional(nameof(IsAttackingTarget))]
		[WireMember(10)]
		public PackedGuid Target { get; }

		[Optional(nameof(HasTransport))]
		[WireMember(11)]
		public uint UnknownTransportTimer { get; }

		[Optional(nameof(IsInVehicle))]
		[WireMember(12)]
		public VehicleMovementInfo VehicleMovementInformation { get; }

		private bool HasUpdateRotation => UpdateFlags.HasFlag(ObjectUpdateFlags.UPDATEFLAG_ROTATION);

		//TODO: Handle packed quaternions. See WoWPacketParser
		[Optional(nameof(HasUpdateRotation))]
		[WireMember(13)]
		public long UpdatePackedQuaternion { get; }

		//TODO: Validate
		/// <inheritdoc />
		public MovementBlockData(ObjectUpdateFlags updateFlags, MovementInfo moveInfo,
			float[] movementSpeeds, SplineInfo splineInformation, CorpseInfo deadMovementInformation,
			StationaryMovementInfo stationaryObjectMovementInformation, int unk1,
			uint lowGuid, PackedGuid target, uint unknownTransportTimer, VehicleMovementInfo vehicleMovementInformation, long packedRotationQuat)
		{
			UpdateFlags = updateFlags;
			MoveInfo = moveInfo;
			MovementSpeeds = movementSpeeds;
			SplineInformation = splineInformation;
			DeadMovementInformation = deadMovementInformation;
			StationaryObjectMovementInformation = stationaryObjectMovementInformation;
			Unk1 = unk1;
			LowGuid = lowGuid;
			Target = target;
			UnknownTransportTimer = unknownTransportTimer;
			VehicleMovementInformation = vehicleMovementInformation;
			UpdatePackedQuaternion = packedRotationQuat;
		}

		public MovementBlockData()
		{
			
		}
	}
}