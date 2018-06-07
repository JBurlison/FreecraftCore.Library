using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class PlayerMoveInfo_Vanilla
	{
		/// <summary>
		/// Indicates if the move info contains
		/// a guid. The default is true.
		/// </summary>
		public bool HasGuid { get; } = true;

		/// <summary>
		/// The GUID of the mover.
		/// </summary>
		[WireMember(1)]
		public PackedGuid MoveGuid { get; }

		/// <summary>
		/// The movement flags.
		/// </summary>
		[WireMember(2)]
		public MovementFlags_Vanilla MoveFlags { get; }

		/// <summary>
		/// TODO
		/// </summary>
		public bool IsOnTransport => MoveFlags.HasFlag(MovementFlags_Vanilla.MOVEFLAG_ONTRANSPORT);

		public bool HasPitch => MoveFlags.HasFlag(MovementFlags_Vanilla.MOVEFLAG_SWIMMING);

		public bool IsFalling => MoveFlags.HasFlag(MovementFlags_Vanilla.MOVEFLAG_FALLING);

		public bool HasSplineElevation => MoveFlags.HasFlag(MovementFlags_Vanilla.MOVEFLAG_SPLINE_ELEVATION);

		[Optional(nameof(IsOnTransport))]
		[WireMember(3)]
		public TransportationInfo_Vanilla OptionalTransportInfo { get; }

		[Optional(nameof(IsOnTransport))]
		[WireMember(4)]
		public int OptionalTransportTime { get; }

		[Optional(nameof(HasPitch))]
		[WireMember(5)]
		public float OptionalPitch { get; }

		//Not optional
		[WireMember(6)]
		public int FallTime { get; }

		[Optional(nameof(IsFalling))]
		[WireMember(7)]
		public Vector4<float> OptionalFallData { get; }

		[Optional(nameof(HasSplineElevation))]
		[WireMember(8)]
		public float OptionalSplineElevation { get; }

		/// <inheritdoc />
		public PlayerMoveInfo_Vanilla([CanBeNull] PackedGuid moveGuid, MovementFlags_Vanilla moveFlags, TransportationInfo_Vanilla optionalTransportInfo, int optionalTransportTime, float optionalPitch, int fallTime, Vector4<float> optionalFallData, float optionalSplineElevation)
		{
			//Might be null, if null then the not send should be set
			if(moveGuid == null)
				HasGuid = false;

			MoveGuid = moveGuid;
			MoveFlags = moveFlags;
			OptionalTransportInfo = optionalTransportInfo;
			OptionalTransportTime = optionalTransportTime;
			OptionalPitch = optionalPitch;
			FallTime = fallTime;
			OptionalFallData = optionalFallData;
			OptionalSplineElevation = optionalSplineElevation;
		}

		/// <inheritdoc />
		public PlayerMoveInfo_Vanilla(MovementFlags_Vanilla moveFlags, TransportationInfo_Vanilla optionalTransportInfo, int optionalTransportTime, float optionalPitch, int fallTime, Vector4<float> optionalFallData, float optionalSplineElevation)
			: this(null, moveFlags, optionalTransportInfo, optionalTransportTime, optionalPitch, fallTime, optionalFallData, optionalSplineElevation)
		{
			this.HasGuid = false;
		}

		protected PlayerMoveInfo_Vanilla()
		{
			
		}
	}
}
