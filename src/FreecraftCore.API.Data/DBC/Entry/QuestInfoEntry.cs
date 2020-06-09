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
	//QuestInfo.dbc
	/// <summary>
	/// Table model for QuestInfo.dbc
	/// https://wowdev.wiki/DB/QuestInfo
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(QuestInfoEntry<>))]
	[Table("QuestInfo")]
	public class QuestInfoEntry<TStringType> : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => QuestInfoId;

		[Key]
		[WireMember(1)]
		public int QuestInfoId { get; internal set; }

		[WireMember(2)]
		public LocalizedStringDBC<TStringType> Name { get; internal set; }

		public QuestInfoEntry(int questInfoId, [NotNull] LocalizedStringDBC<TStringType> name)
		{
			if (questInfoId <= 0) throw new ArgumentOutOfRangeException(nameof(questInfoId));

			QuestInfoId = questInfoId;
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public QuestInfoEntry()
		{
			
		}
	}
}
