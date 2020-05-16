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
		public int CreatureSoundDataId { get; private set; }

		[WireMember(2)]
		public int SoundExertionId { get; private set; }

		[WireMember(3)]
		public int SoundExertionCriticalId { get; private set; }

		[WireMember(4)]
		public int SoundInjuryId { get; private set; }

		[WireMember(5)]
		public int SoundInjuryCriticalId { get; private set; }

		[WireMember(6)]
		public int SoundInjuryCrushingBlowId { get; private set; }

		[WireMember(7)]
		public int SoundDeathId { get; private set; }

		[WireMember(8)]
		public int SoundStunId { get; private set; }

		[WireMember(9)]
		public int SoundStandId { get; private set; }

		/// <summary>
		/// NOT SoundEntries.dbc, but FootstepTerrainLookupRec.m_CreatureFootstepID
		/// AKA FootstepTerrainLookup.dbc
		///
		/// TODO: Implement FootstepTerrainLookup dbc.
		/// </summary>
		[WireMember(10)]
		public int SoundFootstepId { get; private set; }

		[WireMember(11)]
		public int SoundAggroId { get; private set; }

		[WireMember(12)]
		public int SoundWingFlapId { get; private set; }

		[WireMember(13)]
		public int SoundWingGlideId { get; private set; }

		[WireMember(14)]
		public int SoundAlertId { get; private set; }
		
		[WireMember(15)]
		public GenericStaticallySizedArrayChunkFive<int> SoundFidgetId { get; private set; }

		[WireMember(16)]
		public GenericStaticallySizedArrayChunkFour<int> CustomAttackId { get; private set; }

		[WireMember(17)]
		public int NPCSoundId { get; private set; }

		[WireMember(18)]
		public int LoopSoundId { get; private set; }

		/// <summary>
		/// It's not: <see cref="CreatureImpactSound"/>.
		/// Call <see cref="CreatureSoundDataEntryExtensions.GetCreatureImpactType"/> to get actual value.
		/// </summary>
		[WireMember(19)]
		public int CreatureImpactType { get; private set; }

		[WireMember(20)]
		public int SoundJumpStartId { get; private set; }

		[WireMember(21)]
		public int SoundJumpEndId { get; private set; }

		[WireMember(22)]
		public int SoundPetAttackId { get; private set; }

		[WireMember(23)]
		public int SoundPetOrderId { get; private set; }

		/// <summary>
		/// Used by SMSG_PET_DISMISS_SOUND.
		/// </summary>
		[WireMember(24)]
		public int SoundPetDismissId { get; private set; }

		/// <summary>
		/// Time / Interval? 30 seconds?
		/// </summary>
		[WireMember(25)]
		public float FidgetDelaySecondsMinimum { get; private set; }

		/// <summary>
		/// Time / Interval? 60 seconds? 
		/// </summary>
		[WireMember(26)]
		public float FidgetDelaySecondsMaximum { get; private set; }

		[WireMember(27)]
		public int BirthSoundId { get; private set; }

		[WireMember(28)]
		public int SpellCastDirectedSoundId { get; private set; }

		[WireMember(29)]
		public int SubmergeSoundId { get; private set; }

		[WireMember(30)]
		public int SubmergedSoundId { get; private set; }

		/// <summary>
		/// TODO: Unknown, is this SoundData reference or Sound id??
		/// Only used by entry 391 and 2913.
		/// </summary>
		[WireMember(31)]
		public int CreatureSoundDataIdPet { get; private set; }

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
