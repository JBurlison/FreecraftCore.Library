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
	//CharBaseInfo.dbc
	/// <summary>
	/// Table model for CharBaseInfo.dbc
	/// https://wowdev.wiki/DB/CharBaseInfo
	/// Represents combination of valid race and class combinations.
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[Table("CharBaseInfo")]
	public class CharBaseInfoEntry : IDBCEntryIdentifiable
	{
		public static readonly string[] INTERNAL_FIELD_NAMES = new string[] { nameof(ClassId), nameof(RaceId) };

		[NotMapped]
		[JsonIgnore]
		public uint EntryId => (uint) Id;

		/// <summary>
		/// Unique entry key, doesn't mean anything important.
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[WireMember(1)]
		public int Id { get; private set; }

		[WireMember(2)]
		internal byte ClassId { get; private set; }

		[JsonIgnore]
		[ForeignKey(nameof(ClassId))]
		public virtual ChrClassesEntry<string> Class { get; private set; }

		[WireMember(3)]
		internal byte RaceId { get; private set; }

		[JsonIgnore]
		[ForeignKey(nameof(RaceId))]
		public virtual ChrRacesEntry<string> Race { get; private set; }

		public CharBaseInfoEntry(int id, byte classId, byte raceId)
			: this(classId, raceId)
		{
			if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

			Id = id;
		}

		public CharBaseInfoEntry(byte classId, byte raceId)
		{
			ClassId = classId;
			RaceId = raceId;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public CharBaseInfoEntry()
		{
			
		}
	}

	public static class CharBaseInfoEntryExtensions
	{
		public static CharacterRace GetRace([NotNull] this CharBaseInfoEntry entry)
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			return (CharacterRace) entry.RaceId;
		}

		public static CharacterClass GetClass([NotNull] this CharBaseInfoEntry entry)
		{
			if(entry == null) throw new ArgumentNullException(nameof(entry));

			return (CharacterClass) entry.ClassId;
		}
	}
}
