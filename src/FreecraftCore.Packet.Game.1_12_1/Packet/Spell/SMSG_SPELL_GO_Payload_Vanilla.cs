using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	//TODO: What does the opcode actually mean?
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_SPELL_GO)]
	public sealed class SMSG_SPELL_GO_Payload_Vanilla : GamePacketPayload
	{
		//TODO: Are these named right??
		[WireMember(1)]
		public PackedGuid SpellSource { get; internal set; }

		[WireMember(2)]
		public PackedGuid SpellTarget { get; internal set; }

		//1.12.1 doesn't have the cast count
		[WireMember(4)]
		public int SpellId { get; internal set; }

		[WireMember(5)]
		public SpellCastFlags_Vanilla CastFlags { get; internal set; }

		//Spell targets written now.
		//Targets are sent byte prefixed
		//Both a miss and hit block
		[SendSize(SendSizeAttribute.SizeType.Byte)]
		[WireMember(7)]
		public ObjectGuid[] HitTargets { get; internal set; }

		//Not spell misses says Mangos
		[WireMember(8)]
		public byte UnknownByte { get; internal set; } = 0;

		[WireMember(9)]
		public SpellTargetInfo_Vanilla TargetInfo { get; internal set; }

		//TODO: Implement CAST_FLAG_RUNE_LIST for DK stuff
		//Now this is some data optional
		//to the cast flags
		public bool HasAmmo => CastFlags.HasFlag(SpellCastFlag.CAST_FLAG_AMMO);

		[Optional(nameof(HasAmmo))]
		[WireMember(12)]
		public AmmoInfo AmunitionInformation { get; internal set; }

		//TODO: Ctor overloads/builders
		//TODO: Validate parameters
		/// <inheritdoc />
		public SMSG_SPELL_GO_Payload_Vanilla(PackedGuid spellSource, PackedGuid spellTarget, int spellId, SpellCastFlags_Vanilla castFlags, ObjectGuid[] hitTargets, SpellTargetInfo_Vanilla targetInfo, AmmoInfo amunitionInformation)
		{
			SpellSource = spellSource;
			SpellTarget = spellTarget;
			SpellId = spellId;
			CastFlags = castFlags;
			HitTargets = hitTargets;
			TargetInfo = targetInfo;
			AmunitionInformation = amunitionInformation;
		}


		protected SMSG_SPELL_GO_Payload_Vanilla()
		{
			
		}
	}
}
