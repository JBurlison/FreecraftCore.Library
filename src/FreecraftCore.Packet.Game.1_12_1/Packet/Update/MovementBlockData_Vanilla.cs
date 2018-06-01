using FreecraftCore.Serializer;

namespace FreecraftCore
{
	//TODO: Turn into 1.12.1 version. It is still wotlk version
	/// <summary>
	/// The Vanilla 1.12.1 version of <see cref="MovementBlockData"/>.
	/// </summary>
	[WireDataContract]
	public sealed class MovementBlockData_Vanilla
	{
		//In 1.12.1 the objectupdateflags is only 1 byte instead of a short
		/// <summary>
		/// The movement update flags.
		/// </summary>
		[WireMember(1)]
		public ObjectUpdateFlags_Vanilla UpdateFlags { get; }

		//MovementInfo is only sent if the unit is living.
		public bool IsLiving => UpdateFlags.HasFlag(ObjectUpdateFlags_Vanilla.UPDATEFLAG_LIVING);

		public bool HasSplineData => IsLiving && MoveInfo.MovementFlags.HasFlag(MovementFlags_Vanilla.MOVEFLAG_SPLINE_ENABLED);

		public bool IsDead => !IsLiving;

		[Optional(nameof(IsLiving))]
		[WireMember(3)]
		public MovementInfo_Vanilla MoveInfo { get; }

		//Only sent if we're alive
		/// <summary>
		/// Sent if we're alive. Array of <see cref="SpeedType"/>-based speeds.
		/// </summary>
		[Optional(nameof(IsLiving))]
		[KnownSize(6)] //length of SpeedType enum in VanillaWoW is only 6, or only sends 6 here.
		[WireMember(4)]
		public float[] MovementSpeeds { get; } //see SpeedType to understand index.

		//Now there is some optional spline data if we're alive. Too. Great...
		[Optional(nameof(HasSplineData))]
		[WireMember(5)]
		public SplineInfo_Vanilla SplineInformation { get; }

		private bool HasUpdatePosition => UpdateFlags.HasFlag(ObjectUpdateFlags_Vanilla.UPDATEFLAG_HAS_POSITION);

		//The following data requires that we're not living.
		private bool HasCorpseLocation => IsDead && HasUpdatePosition; //TODO: WPP says this is GOPosition

		[Optional(nameof(HasCorpseLocation))]
		[WireMember(6)]
		public CorpseInfo_Vanilla DeadMovementInformation { get; }

		public bool HasHighGuid => UpdateFlags.HasFlag(ObjectUpdateFlags_Vanilla.UPDATEFLAG_HIGHGUID);

		public bool UpdateAll => UpdateFlags.HasFlag(ObjectUpdateFlags_Vanilla.UPDATEFLAG_ALL);

		public bool IncludesFullGuid => UpdateFlags.HasFlag(ObjectUpdateFlags_Vanilla.UPDATEFLAG_FULLGUID);

		public bool HasTransportTimer => UpdateFlags.HasFlag(ObjectUpdateFlags_Vanilla.UPDATEFLAG_TRANSPORT);

		[Optional(nameof(HasHighGuid))]
		[WireMember(7)]
		public uint HighGuid { get; }

		//ClientVersion.RemovedInVersion(ClientVersionBuild.V4_2_2_14545)
		[Optional(nameof(UpdateAll))]
		[WireMember(8)]
		public uint Unk1 { get; } //mangos always send 0x1?

		[Optional(nameof(IncludesFullGuid))]
		[WireMember(9)]
		public PackedGuid FullGuid { get; }

		[Optional(nameof(HasTransportTimer))]
		[WireMember(10)]
		public uint TransportTime { get; }

		//TODO: Validate
		/// <inheritdoc />
		public MovementBlockData_Vanilla(ObjectUpdateFlags_Vanilla updateFlags, MovementInfo_Vanilla moveInfo, float[] movementSpeeds, SplineInfo_Vanilla splineInformation, CorpseInfo_Vanilla deadMovementInformation, uint highGuid, uint unk1, PackedGuid fullGuid, uint transportTime)
		{
			UpdateFlags = updateFlags;
			MoveInfo = moveInfo;
			MovementSpeeds = movementSpeeds;
			SplineInformation = splineInformation;
			DeadMovementInformation = deadMovementInformation;
			HighGuid = highGuid;
			Unk1 = unk1;
			FullGuid = fullGuid;
			TransportTime = transportTime;
		}

		protected MovementBlockData_Vanilla()
		{
			
		}
	}
}