using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	//TODO: What does the opcode actually mean?
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_SPELL_GO)]
	public sealed class SMSG_SPELL_GO_Payload : GamePacketPayload
	{
		//TODO: Are these named right??
		[WireMember(1)]
		public PackedGuid SpellSource { get; }

		[WireMember(2)]
		public PackedGuid SpellTarget { get; }

		//TC says:  pending spell cast?
		[WireMember(3)]
		public byte SpellCastCount { get; }

		[WireMember(4)]
		public int SpellId { get; }

		[WireMember(5)]
		public SpellCastFlag CastFlags { get; }

		/// <summary>
		/// The time since the server started.
		/// </summary>
		[WireMember(6)]
		public uint TimeDiff { get; }

		//Spell targets written now.
		//Targets are sent byte prefixed
		//Both a miss and hit block
		[SendSize(SendSizeAttribute.SizeType.Byte)]
		[WireMember(7)]
		public ObjectGuid[] HitTargets { get; }

		[SendSize(SendSizeAttribute.SizeType.Byte)]
		[WireMember(8)]
		public SpellMissInfo[] SpellMisses { get; }

		[WireMember(9)]
		public SpellTargetInfo TargetInfo { get; }

		//TODO: Implement CAST_FLAG_RUNE_LIST for DK stuff
		//Now this is some data optional
		//to the cast flags

		public bool HasPowerInformation => CastFlags.HasFlag(SpellCastFlag.CAST_FLAG_POWER_LEFT_SELF);

		public bool HasAdjustableMissle => CastFlags.HasFlag(SpellCastFlag.CAST_FLAG_ADJUST_MISSILE);

		public bool HasAmmo => CastFlags.HasFlag(SpellCastFlag.CAST_FLAG_AMMO);

		public bool HasVisualChainData => CastFlags.HasFlag(SpellCastFlag.CAST_FLAG_VISUAL_CHAIN);

		private bool HasTargetUnknownByte => TargetInfo != null && TargetInfo.HasTransportDestinationLocation;

		[Optional(nameof(HasPowerInformation))]
		[WireMember(10)]
		public int PowerValue { get; }

		[Optional(nameof(HasAdjustableMissle))]
		[WireMember(11)]
		public AdjustableSpellMissleInfo OptionalAdjustableMissle { get; }

		[Optional(nameof(HasAmmo))]
		[WireMember(12)]
		public AmmoInfo AmunitionInformation { get; }

		//TODO: What is this?
		[Optional(nameof(HasVisualChainData))]
		[WireMember(13)]
		public ulong OptionalVisualChainData { get; }

		[Optional(nameof(HasTargetUnknownByte))]
		[WireMember(14)]
		public byte UnkownTargetDestByte { get; } = 0; //TC always uses 0

		//TODO: Ctor overloads/builders
		//TODO: Validate parameters
		/// <inheritdoc />
		public SMSG_SPELL_GO_Payload(PackedGuid spellSource, PackedGuid spellTarget, byte spellCastCount, int spellId, SpellCastFlag castFlags, uint timeDiff, 
			ObjectGuid[] hitTargets, SpellMissInfo[] spellMisses, SpellTargetInfo targetInfo, int powerValue, AdjustableSpellMissleInfo optionalAdjustableMissle, 
			AmmoInfo amunitionInformation, ulong optionalVisualChainData)
		{
			SpellSource = spellSource;
			SpellTarget = spellTarget;
			SpellCastCount = spellCastCount;
			SpellId = spellId;
			CastFlags = castFlags;
			TimeDiff = timeDiff;
			HitTargets = hitTargets;
			SpellMisses = spellMisses;
			TargetInfo = targetInfo;
			PowerValue = powerValue;
			OptionalAdjustableMissle = optionalAdjustableMissle;
			AmunitionInformation = amunitionInformation;
			OptionalVisualChainData = optionalVisualChainData;
		}

		protected SMSG_SPELL_GO_Payload()
		{
			
		}
	}
}
