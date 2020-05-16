using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;
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
		internal static int IdentityId = 0;

		//Unique case where there is no id and we need to increment if we're loading from file.
		[NotMapped]
		[JsonIgnore]
		public int EntryId => (Id == 0 ? Id = Interlocked.Increment(ref IdentityId) : Id);

		/// <summary>
		/// Unique entry key, doesn't mean anything important.
		/// </summary>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//[WireMember(1)] // Unique DBC that does not have a unique key and does not really have an ID.
		public int Id { get; private set; }

		/// <summary>
		/// Foreign key to: <see cref="ChrRacesEntry{TStringType}"/>
		/// Foreign key is manually configured.
		/// </summary>
		[Column(TypeName = "int")]
		[WireMember(2)]
		public byte RaceId { get; private set; } //not internal due to EF Core limitations

		/// <summary>
		/// Foreign key to: <see cref="ChrClassesEntry{TStringType}"/>
		/// Foreign key is manually configured.
		/// </summary>
		[Column(TypeName = "int")]
		[WireMember(3)]
		public byte ClassId { get; private set; } //not internal due to EF Core limitations

		//Don't think there is a padding in 3.3.5
		/*/// <summary>
		/// 2 bytes of padding that is unused by the the DBC reading. Always 0.
		/// First 2 bytes are ClassRace mask.
		/// </summary>
		[JsonIgnore]
		[NotMapped]
		[WireMember(4)]
		internal short Padding { get; private set; }*/

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
