using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class SpellTargetInfo_Vanilla
	{
		[WireMember(1)]
		private short SpellCastBackingFlag { get; }

		public SpellCastTargetFlag TargetFlags => (SpellCastTargetFlag)SpellCastBackingFlag;

		public bool HasObjectTarget => (TargetFlags & (SpellCastTargetFlag.TARGET_FLAG_UNIT
			| SpellCastTargetFlag.TARGET_FLAG_UNIT_MINIPET | SpellCastTargetFlag.TARGET_FLAG_GAMEOBJECT
			| SpellCastTargetFlag.TARGET_FLAG_CORPSE_ENEMY | SpellCastTargetFlag.TARGET_FLAG_CORPSE_ALLY)) != 0;

		public bool HasItemTarget =>
			(TargetFlags & (SpellCastTargetFlag.TARGET_FLAG_ITEM | SpellCastTargetFlag.TARGET_FLAG_TRADE_ITEM)) != 0;

		public bool HasTransportSourceLocation => TargetFlags.HasFlag(SpellCastTargetFlag.TARGET_FLAG_SOURCE_LOCATION);

		public bool HasTransportDestinationLocation => TargetFlags.HasFlag(SpellCastTargetFlag.TARGET_FLAG_DEST_LOCATION);

		public bool HasTargetString => TargetFlags.HasFlag(SpellCastTargetFlag.TARGET_FLAG_STRING);

		//TODO: Can this ever have both TARGET_FLAG_SOURCE_LOCATION and TARGET_FLAG_DEST_LOCATION?
		[Optional(nameof(HasObjectTarget))]
		[WireMember(2)]
		public PackedGuid OptionalObjectTarget { get; }

		[Optional(nameof(HasItemTarget))]
		[WireMember(3)]
		public PackedGuid OptionalItemTarget { get; }

		//Could be offset or position. It depends on if the guid is empty
		[Optional(nameof(HasTransportSourceLocation))]
		[WireMember(5)]
		public Vector3<float> OptionalTransportSourcePosition { get; }

		//Could be offset or position. It depends on if the dest guid is empty.
		[Optional(nameof(HasTransportDestinationLocation))]
		[WireMember(7)]
		public Vector3<float> OptionalTransportDestinationPosition { get; }

		//Null terminator ASCII
		[Encoding(EncodingType.ASCII)]
		[Optional(nameof(HasTargetString))]
		[WireMember(8)]
		public string OptionalTargetString { get; }

		//TODO: Ctor overloads/builder.
		//TODO: Validate parameters
		/// <inheritdoc />
		public SpellTargetInfo_Vanilla(short spellCastBackingFlag, PackedGuid optionalObjectTarget, PackedGuid optionalItemTarget, Vector3<float> optionalTransportSourcePosition, Vector3<float> optionalTransportDestinationPosition, string optionalTargetString)
		{
			SpellCastBackingFlag = spellCastBackingFlag;
			OptionalObjectTarget = optionalObjectTarget;
			OptionalItemTarget = optionalItemTarget;
			OptionalTransportSourcePosition = optionalTransportSourcePosition;
			OptionalTransportDestinationPosition = optionalTransportDestinationPosition;
			OptionalTargetString = optionalTargetString;
		}

		protected SpellTargetInfo_Vanilla()
		{

		}
	}
}