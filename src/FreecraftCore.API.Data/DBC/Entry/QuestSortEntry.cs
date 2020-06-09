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
	//QuestSort.dbc
	/// <summary>
	/// Table model for QuestSort.dbc
	/// https://wowdev.wiki/DB/QuestSort
	/// This DBC is responsible for listing the non-area categories
	/// used for quest grouping. Alternatively categories are defined
	/// by the AreaTable DBC.
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(QuestSortEntry<>))]
	[Table("QuestSort")]
	public class QuestSortEntry<TStringType> : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => QuestSortId;

		[Key]
		[WireMember(1)]
		public int QuestSortId { get; internal set; }

		/// <summary>
		/// Name of the category.
		/// </summary>
		[WireMember(2)]
		public LocalizedStringDBC<TStringType> CategoryName { get; internal set; }

		public QuestSortEntry(int questSortId, [NotNull] LocalizedStringDBC<TStringType> categoryName)
		{
			if (questSortId <= 0) throw new ArgumentOutOfRangeException(nameof(questSortId));

			QuestSortId = questSortId;
			CategoryName = categoryName ?? throw new ArgumentNullException(nameof(categoryName));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public QuestSortEntry()
		{
			
		}
	}
}
