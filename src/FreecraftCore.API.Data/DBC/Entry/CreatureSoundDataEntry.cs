using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//CreatureSoundData.dbc
	/// <summary>
	/// Table model for CreatureSoundData.dbc
	/// https://wowdev.wiki/DB/CreatureSoundData
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[Table("CreatureSoundData")]
	public class CreatureSoundDataEntry : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => CreatureSoundDataId;

		[Key]
		[WireMember(1)]
		public int CreatureSoundDataId { get; internal set; }

		[WireMember(2)]
		public int SoundExertionId { get; internal set; }

		[WireMember(3)]
		public int SoundExertionCriticalId { get; internal set; }

		[WireMember(4)]
		public int SoundInjuryId { get; internal set; }

		[WireMember(5)]
		public int SoundInjuryCriticalId { get; internal set; }

		[WireMember(6)]
		public int SoundInjuryCrushingBlowId { get; internal set; }

		[WireMember(7)]
		public int SoundDeathId { get; internal set; }

		[WireMember(8)]
		public int SoundStunId { get; internal set; }

		[WireMember(9)]
		public int SoundStandId { get; internal set; }

		/// <summary>
		/// NOT SoundEntries.dbc, but FootstepTerrainLookupRec.m_CreatureFootstepID
		/// AKA FootstepTerrainLookup.dbc
		///
		/// TODO: Implement FootstepTerrainLookup dbc.
		/// </summary>
		[WireMember(10)]
		public int SoundFootstepId { get; internal set; }

		[WireMember(11)]
		public int SoundAggroId { get; internal set; }

		[WireMember(12)]
		public int SoundWingFlapId { get; internal set; }

		[WireMember(13)]
		public int SoundWingGlideId { get; internal set; }

		[WireMember(14)]
		public int SoundAlertId { get; internal set; }
		
		[WireMember(15)]
		public GenericStaticallySizedArrayChunkFive<int> SoundFidgetId { get; internal set; }

		[WireMember(16)]
		public GenericStaticallySizedArrayChunkFour<int> CustomAttackId { get; internal set; }

		[WireMember(17)]
		public int NPCSoundId { get; internal set; }

		[WireMember(18)]
		public int LoopSoundId { get; internal set; }

		/// <summary>
		/// It's not: <see cref="CreatureImpactSound"/>.
		/// Call <see cref="CreatureSoundDataEntryExtensions.GetCreatureImpactType"/> to get actual value.
		/// </summary>
		[WireMember(19)]
		public int CreatureImpactType { get; internal set; }

		[WireMember(20)]
		public int SoundJumpStartId { get; internal set; }

		[WireMember(21)]
		public int SoundJumpEndId { get; internal set; }

		[WireMember(22)]
		public int SoundPetAttackId { get; internal set; }

		[WireMember(23)]
		public int SoundPetOrderId { get; internal set; }

		/// <summary>
		/// Used by SMSG_PET_DISMISS_SOUND.
		/// </summary>
		[WireMember(24)]
		public int SoundPetDismissId { get; internal set; }

		/// <summary>
		/// Time / Interval? 30 seconds?
		/// </summary>
		[WireMember(25)]
		public float FidgetDelaySecondsMinimum { get; internal set; }

		/// <summary>
		/// Time / Interval? 60 seconds? 
		/// </summary>
		[WireMember(26)]
		public float FidgetDelaySecondsMaximum { get; internal set; }

		[WireMember(27)]
		public int BirthSoundId { get; internal set; }

		[WireMember(28)]
		public int SpellCastDirectedSoundId { get; internal set; }

		[WireMember(29)]
		public int SubmergeSoundId { get; internal set; }

		[WireMember(30)]
		public int SubmergedSoundId { get; internal set; }

		/// <summary>
		/// TODO: Unknown, is this SoundData reference or Sound id??
		/// Only used by entry 391 and 2913.
		/// </summary>
		[WireMember(31)]
		public int CreatureSoundDataIdPet { get; internal set; }

		public CreatureSoundDataEntry(int creatureSoundDataId, int soundExertionId, int soundExertionCriticalId, int soundInjuryId, int soundInjuryCriticalId, int soundInjuryCrushingBlowId, int soundDeathId, int soundStunId, int soundStandId, int soundFootstepId, int soundAggroId, int soundWingFlapId, int soundWingGlideId, int soundAlertId, [NotNull] GenericStaticallySizedArrayChunkFive<int> soundFidgetId, [NotNull] GenericStaticallySizedArrayChunkFour<int> customAttackId, int npcSoundId, int loopSoundId, int creatureImpactType, int soundJumpStartId, int soundJumpEndId, int soundPetAttackId, int soundPetOrderId, int soundPetDismissId, float fidgetDelaySecondsMinimum, float fidgetDelaySecondsMaximum, int birthSoundId, int spellCastDirectedSoundId, int submergeSoundId, int submergedSoundId, int creatureSoundDataIdPet)
		{
			if (creatureSoundDataId <= 0) throw new ArgumentOutOfRangeException(nameof(creatureSoundDataId));

			CreatureSoundDataId = creatureSoundDataId;
			SoundExertionId = soundExertionId;
			SoundExertionCriticalId = soundExertionCriticalId;
			SoundInjuryId = soundInjuryId;
			SoundInjuryCriticalId = soundInjuryCriticalId;
			SoundInjuryCrushingBlowId = soundInjuryCrushingBlowId;
			SoundDeathId = soundDeathId;
			SoundStunId = soundStunId;
			SoundStandId = soundStandId;
			SoundFootstepId = soundFootstepId;
			SoundAggroId = soundAggroId;
			SoundWingFlapId = soundWingFlapId;
			SoundWingGlideId = soundWingGlideId;
			SoundAlertId = soundAlertId;
			SoundFidgetId = soundFidgetId ?? throw new ArgumentNullException(nameof(soundFidgetId));
			CustomAttackId = customAttackId ?? throw new ArgumentNullException(nameof(customAttackId));
			NPCSoundId = npcSoundId;
			LoopSoundId = loopSoundId;
			CreatureImpactType = creatureImpactType;
			SoundJumpStartId = soundJumpStartId;
			SoundJumpEndId = soundJumpEndId;
			SoundPetAttackId = soundPetAttackId;
			SoundPetOrderId = soundPetOrderId;
			SoundPetDismissId = soundPetDismissId;
			FidgetDelaySecondsMinimum = fidgetDelaySecondsMinimum;
			FidgetDelaySecondsMaximum = fidgetDelaySecondsMaximum;
			BirthSoundId = birthSoundId;
			SpellCastDirectedSoundId = spellCastDirectedSoundId;
			SubmergeSoundId = submergeSoundId;
			SubmergedSoundId = submergedSoundId;
			CreatureSoundDataIdPet = creatureSoundDataIdPet;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public CreatureSoundDataEntry()
		{
			
		}
	}

	//TODO: Support enum based lookup of sound ids or HasDefinedSound too.
	public static class CreatureSoundDataEntryExtensions
	{
		public static CreatureImpactSound GetCreatureImpactType([NotNull] this CreatureSoundDataEntry entry)
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			// index into s_creatureIpactSounds
			return CreatureImpactSoundExtensions.CreatureImpactSoundArray[entry.CreatureImpactType];
		}
	}
}
