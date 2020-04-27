using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//CinematicSequences.dbc
	/// <summary>
	/// Table model for CinematicSequences.dbc
	/// https://wowdev.wiki/DB/CinematicSequences
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[Table("CinematicSequences")]
	public class CinematicSequencesEntry : IDBCEntryIdentifiable
	{
		public static readonly string[] INTERNAL_FIELD_NAMES = new string[1] { nameof(UnusedCameraId) };

		[NotMapped]
		[JsonIgnore]
		public uint EntryId => (uint) SequenceId;

		[Key]
		[WireMember(1)]
		public int SequenceId { get; private set; }

		/// <summary>
		/// Nullable.
		/// Unused.
		/// See: <see cref="SoundEntriesEntry{TStringType}"/>.
		/// </summary>
		[WireMember(2)]
		public int SoundId { get; private set; }

		/// <summary>
		/// Non-nullable.
		/// See: <see cref="CinematicCameraEntry{TStringType}"/>
		/// </summary>
		[WireMember(3)]
		public int CameraId { get; private set; }

		[JsonIgnore]
		[ForeignKey(nameof(CameraId))]
		public virtual CinematicCameraEntry<string> Camera { get; private set; }

		/// <summary>
		/// Never used in Blizzlike DBC.
		/// </summary>
		[WireMember(4)]
		internal GenericStaticallySizedArrayChunkSeven<int> UnusedCameraId { get; private set; }

		public CinematicSequencesEntry(int sequenceId, int soundId, int cameraId, [NotNull] GenericStaticallySizedArrayChunkSeven<int> unusedCameraId)
		{
			if (sequenceId <= 0) throw new ArgumentOutOfRangeException(nameof(sequenceId));
			if (cameraId <= 0) throw new ArgumentOutOfRangeException(nameof(cameraId));

			SequenceId = sequenceId;
			SoundId = soundId;
			CameraId = cameraId;
			UnusedCameraId = unusedCameraId ?? throw new ArgumentNullException(nameof(unusedCameraId));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public CinematicSequencesEntry()
		{
			
		}
	}
}
