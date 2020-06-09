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
	//QuestXP.dbc
	/// <summary>
	/// Table model for QuestXP.dbc
	/// https://wowdev.wiki/DB/QuestXP
	/// Poorly named. It's basically base-reward based on level and quest difficulty.
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[Table("QuestXP")]
	public class QuestXPEntry : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => Level;

		[Key]
		[WireMember(1)]
		public int Level { get; internal set; }

		[WireMember(2)]
		public GenericStaticallySizedArrayChunkTen<int> DifficultyReward { get; internal set; }

		public QuestXPEntry(int level, [NotNull] GenericStaticallySizedArrayChunkTen<int> difficultyReward)
		{
			if (level <= 0) throw new ArgumentOutOfRangeException(nameof(level));

			Level = level;
			DifficultyReward = difficultyReward ?? throw new ArgumentNullException(nameof(difficultyReward));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public QuestXPEntry()
		{
			
		}
	}
}
