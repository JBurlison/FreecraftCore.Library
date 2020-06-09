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
	//SoundEntries.dbc
	/// <summary>
	/// Table model for SoundEntries.dbc
	/// https://wowdev.wiki/DB/SoundEntries
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(SoundEntriesEntry<>))]
	[Table("SoundEntries")]
	public class SoundEntriesEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => SoundId;

		[Key]
		[WireMember(1)]
		public int SoundId { get; internal set; }

		[WireMember(2)]
		public SoundTypes SoundType { get; internal set; }

		[WireMember(3)]
		public TStringType Name { get; internal set; }

		[WireMember(4)]
		public GenericStaticallySizedArrayChunkTen<TStringType> File { get; internal set; }

		[WireMember(5)]
		public GenericStaticallySizedArrayChunkTen<int> Frequency { get; internal set; }

		[WireMember(6)]
		public TStringType BaseDirectory { get; internal set; }
		
		[WireMember(7)]
		public float Volume { get; internal set; }

		[WireMember(8)]
		public SoundInterfaceFlags Flags { get; internal set; }

		[WireMember(9)]
		public float MinimumDistance { get; internal set; }

		[WireMember(10)]
		public float DistanceCutoff { get; internal set; }

		/// <summary>
		/// See: https://en.wikipedia.org/wiki/Environmental_Audio_Extensions
		/// TODO: What do the values mean??
		/// </summary>
		[WireMember(11)]
		public int EAXDefinition { get; internal set; }

		/// <summary>
		/// Reference to SoundEntriesAdvanced.dbc.
		/// </summary>
		[WireMember(12)]
		public int SoundEntriesAdvancedId { get; internal set; }

		public SoundEntriesEntry(int soundId, SoundTypes soundType, [NotNull] TStringType name, [NotNull] GenericStaticallySizedArrayChunkTen<TStringType> file, [NotNull] GenericStaticallySizedArrayChunkTen<int> frequency, [NotNull] TStringType baseDirectory, float volume, SoundInterfaceFlags flags, float minimumDistance, float distanceCutoff, int eaxDefinition, int soundEntriesAdvancedId)
		{
			if (!Enum.IsDefined(typeof(SoundTypes), soundType)) throw new InvalidEnumArgumentException(nameof(soundType), (int) soundType, typeof(SoundTypes));
			if (soundId <= 0) throw new ArgumentOutOfRangeException(nameof(soundId));

			SoundId = soundId;
			SoundType = soundType;
			Name = name ?? throw new ArgumentNullException(nameof(name));
			File = file ?? throw new ArgumentNullException(nameof(file));
			Frequency = frequency ?? throw new ArgumentNullException(nameof(frequency));
			BaseDirectory = baseDirectory ?? throw new ArgumentNullException(nameof(baseDirectory));
			Volume = volume;
			Flags = flags;
			MinimumDistance = minimumDistance;
			DistanceCutoff = distanceCutoff;
			EAXDefinition = eaxDefinition;
			SoundEntriesAdvancedId = soundEntriesAdvancedId;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public SoundEntriesEntry()
		{
			
		}
	}
}
