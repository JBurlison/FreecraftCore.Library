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
	//LanguageWords.dbc
	/// <summary>
	/// Table model for LanguageWords.dbc
	/// https://wowdev.wiki/DB/LanguageWords
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(LanguageWordsEntry<>))]
	[Table("LanguageWords")]
	public class LanguageWordsEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => Id;

		/// <summary>
		/// Unique key for the entry.
		/// </summary>
		[Key]
		[WireMember(1)]
		public int Id { get; internal set; }

		/// <summary>
		/// Non-nullable
		/// See: <see cref="LanguagesEntry{TStringType}"/>
		/// </summary>
		[WireMember(2)]
		public int LanguageId { get; internal set; }

		/// <summary>
		/// Non-nullable
		/// See: <see cref="LanguagesEntry{TStringType}"/>
		/// </summary>
		[ForeignKey(nameof(LanguageId))]
		[JsonIgnore]
		public virtual LanguagesEntry<TStringType> Language { get; private set; }

		/// <summary>
		/// Replacement word.
		/// </summary>
		[WireMember(3)]
		public TStringType Word { get; internal set; }

		public LanguageWordsEntry(int id, int languageId, [NotNull] TStringType word)
		{
			if (languageId <= 0) throw new ArgumentOutOfRangeException(nameof(languageId));
			if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

			Id = id;
			LanguageId = languageId;
			Word = word ?? throw new ArgumentNullException(nameof(word));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public LanguageWordsEntry()
		{
			
		}
	}

	/*ChatTranslate::Translate
	* On initialization, the client groups this table into s_wordList by m_languageID and strlen (m_word), maintaining order of records like in the DB.
	* On translation,
		* the client first checks if languageSkill for the given language is >=300. If yes, the text is not modified.
		* Hyperlinks are stripped.
		* Everything is UTF8-aware. Older versions (e.g. Vanilla) are not.
		* Text is split into words.
			* wordHash = SStrHash (word, false, 0)
			* If wordHash % 300 < languageSkill, the word is not modified.
			* wordLen is UTF8-aware, but limited to a maximum of 18.
			* s_wordList is searched for the first group having the right languageID and wordLen. If none is found, wordLen - 1 is tried, until wordLen == 1.
			* If no group is found, the word is not modified.
			* The wordHash % group.sizeth entry is taken and the word is replaced with m_word.
			* Depending on client locale, characters that are uppercase in the input force the replacement word's character to also be upper case. Some other locales copy the exact case (so also toLower()). In older versions, the CopyWordCase is called unconditionally of locale.*/

	/*static char upper_backslash (char c) {
			return c == '/' ? '\\' : toupper (c);
		}
		static uint32_t const s_hashtable[16] = {
		  0x486E26EE, 0xDCAA16B3, 0xE1918EEF, 0x202DAFDB,
		  0x341C7DC7, 0x1C365303, 0x40EF2D37, 0x65FD5E49,
		  0xD6057177, 0x904ECE93, 0x1C38024F, 0x98FD323B,
		  0xE3061AE7, 0xA39B0FA1, 0x9797F25F, 0xE4444563,
		};
		uint32_t SStrHash (char const* string, bool no_caseconv, uint32_t seed)
		{
		  assert (string);
		  if (!seed) {
		    seed = 0x7FED7FED;
		  }

		  uint32_t shift = 0xEEEEEEEE;
		  while (*string) {
		    char c = *string++;
		    if (!no_caseconv) {
		      c = upper_backslash (c);
		    }

		    seed = (s_hashtable[c >> 4] - s_hashtable[c & 0xF]) ^ (shift + seed);
		    shift = c + seed + 33 * shift + 3;
		  }

		  return seed ? seed : 1;
		}*/
}
