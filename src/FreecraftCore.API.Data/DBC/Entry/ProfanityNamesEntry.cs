using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//NamesProfanity.dbc
	/// <summary>
	/// Table model for NamesProfanity.dbc
	/// https://wowdev.wiki/DB/NamesProfanity
	/// </summary>
	[DBC]
	[StringDBC(typeof(ProfanityNamesEntry<>))]
	[WireDataContract]
	[JsonObject]
	[Table("NamesProfanity")]
	public sealed class ProfanityNamesEntry<TStringType> : IDBCEntryIdentifiable
	{
		/// <inheritdoc />
		public int EntryId => ProfanityNamesId;

		[Key]
		[WireMember(1)]
		public int ProfanityNamesId { get; internal set; }

		[WireMember(2)]
		public TStringType Pattern { get; internal set; }

		[WireMember(3)]
		public uint LanguageID { get; internal set; }

		/// <inheritdoc />
		public ProfanityNamesEntry(int profanityNamesId, TStringType pattern, uint languageId)
		{
			ProfanityNamesId = profanityNamesId;
			Pattern = pattern;
			LanguageID = languageId;
		}

		public ProfanityNamesEntry()
		{
			
		}
	}
}
