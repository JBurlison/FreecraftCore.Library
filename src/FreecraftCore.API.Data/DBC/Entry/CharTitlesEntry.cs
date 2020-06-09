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
	//CharTitles.dbc
	/// <summary>
	/// Table model for CharTitles.dbc
	/// https://wowdev.wiki/DB/CharTitles
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(CharTitlesEntry<>))]
	[Table("CharTitles")]
	public class CharTitlesEntry<TStringType> : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => TitleId;

		[Key]
		[WireMember(1)]
		public int TitleId { get; internal set; }

		/// <summary>
		/// Nullable.
		/// Unknown possible serverside condition or script id.
		/// </summary>
		[WireMember(2)]
		public int ConditionId { get; internal set; }

		/// <summary>
		/// Male version of the title.
		/// </summary>
		[WireMember(3)]
		public LocalizedStringDBC<TStringType> MaleName { get; internal set; }

		/// <summary>
		/// Female version of the title.
		/// </summary>
		[WireMember(4)]
		public LocalizedStringDBC<TStringType> FemaleName { get; internal set; }

		/// <summary>
		/// Unique and secondary key for <see cref="CharTitlesEntry{TStringType}"/> that indicates
		/// the bit to be used in bitmasking/bitwise calculations involving this character title.
		/// Used ingame in the drop down menu. (186 is max value, check characters.characters structure for more info)
		/// </summary>
		[WireMember(5)]
		public int TitleBit { get; internal set; }

		public CharTitlesEntry(int titleId, int conditionId, [NotNull] LocalizedStringDBC<TStringType> maleName, [NotNull] LocalizedStringDBC<TStringType> femaleName, int titleBit)
		{
			if (titleId <= 0) throw new ArgumentOutOfRangeException(nameof(titleId));
			if (titleBit <= 0) throw new ArgumentOutOfRangeException(nameof(titleBit));

			TitleId = titleId;
			ConditionId = conditionId;
			MaleName = maleName ?? throw new ArgumentNullException(nameof(maleName));
			FemaleName = femaleName ?? throw new ArgumentNullException(nameof(femaleName));
			TitleBit = titleBit;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public CharTitlesEntry()
		{
			
		}
	}
}
