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
	//Languages.dbc
	/// <summary>
	/// Table model for Languages.dbc
	/// https://wowdev.wiki/DB/Languages
	/// If changes are made then <see cref="ChatLanguage"/> must be updated.
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(LanguagesEntry<>))]
	[Table("Languages")]
	public class LanguagesEntry<TStringType> : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => LanguageId;

		[Key]
		[WireMember(1)]
		public int LanguageId { get; private set; }

		/// <summary>
		/// The localized name of the language.
		/// </summary>
		[WireMember(2)]
		public LocalizedStringDBC<TStringType> Name { get; private set; }

		public LanguagesEntry(int languageId, [NotNull] LocalizedStringDBC<TStringType> name)
		{
			if (languageId <= 0) throw new ArgumentOutOfRangeException(nameof(languageId));

			LanguageId = languageId;
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public LanguagesEntry()
		{
			
		}
	}

	public static class LanguagesEntryExtensions
	{
		public static ChatLanguage ToLanguageEnum<TStringType>([NotNull] this LanguagesEntry<TStringType> entry)
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			return (ChatLanguage) entry.LanguageId;
		}
	}
}
