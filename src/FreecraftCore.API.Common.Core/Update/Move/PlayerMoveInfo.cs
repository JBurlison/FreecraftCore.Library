using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// The player's movement info.
	/// It is slightly different than <see cref="MovementInfo"/>.
	/// </summary>
	[WireDataContract]
	public sealed class PlayerMoveInfo
	{
		//Why is this sent? Shouldn't the server know who is moving us?
		/// <summary>
		/// The GUID of the mover.
		/// </summary>
		[WireMember(1)]
		public PackedGuid MovementGuid { get; }

		[WireMember(2)]
		public MovementFlag MoveFlags { get; }

		[WireMember(3)]
		public MovementFlagExtra ExtraMoveFlags { get; }

		/// <summary>
		/// Indicates if the optional <see cref="OptionalTransportInfo"/> is
		/// included in the packet.
		/// </summary>
		public bool HasTransportInformation => MoveFlags.HasFlag(MovementFlag.MOVEMENTFLAG_ONTRANSPORT);

		public bool HasTransportationInterpolationTime =>
			HasTransportInformation && ExtraMoveFlags.HasFlag(MovementFlagExtra.InterpolateMove);

		public bool HasPitch =>
			MoveFlags.HasFlag(MovementFlag.MOVEMENTFLAG_SWIMMING | MovementFlag.MOVEMENTFLAG_FLYING)
			|| ExtraMoveFlags.HasFlag(MovementFlagExtra.AlwaysAllowPitching);

		public bool HasFallingInformation => MoveFlags.HasFlag(MovementFlag.MOVEMENTFLAG_FALLING);

		public bool HasSplineElevation => MoveFlags.HasFlag(MovementFlag.MOVEMENTFLAG_SPLINE_ELEVATION);

		[Optional(nameof(HasTransportInformation))]
		[WireMember(4)]
		public TransportationInfo OptionalTransportInfo { get; }

		[Optional(nameof(HasTransportationInterpolationTime))]
		[WireMember(5)]
		public int TransportInterpolationTime { get; }

		[Optional(nameof(HasPitch))]
		[WireMember(6)]
		public float OptionalPitch { get; }

		//Not optional, always has it.
		[WireMember(7)]
		public int FallTime { get; }

		[Optional(nameof(HasFallingInformation))]
		[WireMember(8)]
		public Vector4<float> OptionalFallingInfo { get; }

		[Optional(nameof(HasSplineElevation))]
		[WireMember(9)]
		public float OptionalSplineElevation { get; }

		//TODO: Validate parameters
		//TODO: Ctor overloads
		public PlayerMoveInfo(PackedGuid movementGuid, MovementFlag moveFlags, MovementFlagExtra extraMoveFlags, TransportationInfo optionalTransportInfo, int transportInterpolationTime, float optionalPitch, int fallTime, Vector4<float> optionalFallingInfo, float optionalSplineElevation)
		{
			MovementGuid = movementGuid;
			MoveFlags = moveFlags;
			ExtraMoveFlags = extraMoveFlags;
			OptionalTransportInfo = optionalTransportInfo;
			TransportInterpolationTime = transportInterpolationTime;
			OptionalPitch = optionalPitch;
			FallTime = fallTime;
			OptionalFallingInfo = optionalFallingInfo;
			OptionalSplineElevation = optionalSplineElevation;
		}

		protected PlayerMoveInfo()
		{
			
		}
	}
}
