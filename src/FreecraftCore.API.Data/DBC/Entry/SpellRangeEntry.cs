using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//Referenced by Spell.dbc
	[DBC]
	[StringDBC(typeof(SpellRangeEntry<>))]
	[Table("SpellRange")]
	[JsonObject]
	[WireDataContract]
	public class SpellRangeEntry<TStringType> : IDBCEntryIdentifiable
	{
		//TODO: Is this spell id? Or another id?
		/// <inheritdoc />
		[JsonIgnore]
		[NotMapped]
		public int EntryId => SpellRangeId;

		[Key]
		[WireMember(1)]
		public int SpellRangeId { get; internal set; }

		[WireMember(2)]
		public float MinRange { get; internal set; }

		[WireMember(3)]
		public float MinRangeFriendly { get; internal set; }

		[WireMember(4)]
		public float MaxRange { get; internal set; }

		[WireMember(5)]
		public float MaxRangeFriendly { get; internal set; }

		//TODO: What does this field do?

		[WireMember(6)]
		public uint Field5 { get; internal set; }

		[WireMember(7)]
		public LocalizedStringDBC<TStringType> Description1 { get; internal set; }

		[WireMember(8)]
		public LocalizedStringDBC<TStringType> Description2 { get; internal set; }

		/// <inheritdoc />
		public SpellRangeEntry(int spellRangeId, float minRange, float minRangeFriendly, float maxRange, float maxRangeFriendly, uint field5, LocalizedStringDBC<TStringType> description1, LocalizedStringDBC<TStringType> description2)
		{
			SpellRangeId = spellRangeId;
			MinRange = minRange;
			MinRangeFriendly = minRangeFriendly;
			MaxRange = maxRange;
			MaxRangeFriendly = maxRangeFriendly;
			Field5 = field5;
			Description1 = description1;
			Description2 = description2;
		}

		/// <summary>
		/// Serializer ctor
		/// </summary>
		public SpellRangeEntry()
		{
			
		}
	}
}
