using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//Achievement_Criteria.dbc
	/// <summary>
	/// Table model for Achievement_Criteria.dbc
	/// https://wowdev.wiki/DB/Achievement_Category
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(AchievementCriteriaEntry<>))]
	[Table("Achievement_Criteria")]
	public class AchievementCriteriaEntry<TStringType> : IDBCEntryIdentifiable, IDBCUIOrderable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => AchievementCriteriaId;

		[Key]
		[WireMember(1)]
		public int AchievementCriteriaId { get; internal set; }

		/// <summary>
		/// The referenced achievement id.
		/// </summary>
		[WireMember(2)]
		public int ReferredAchievementId { get; internal set; }

		[JsonIgnore]
		[ForeignKey(nameof(ReferredAchievementId))]
		public virtual AchievementEntry<TStringType> AchievementEntry { get; private set; }

		[WireMember(3)]
		public AchievementCriteriaTypes Type { get; internal set; }

		//See TC DBC implementation to understand these.
		[WireMember(4)]
		public int AssetId { get; internal set; }

		[WireMember(5)]
		public int Amount { get; internal set; }

		[WireMember(6)]
		public AchievementCriteriaConditionDefinition Start { get; internal set; }

		[WireMember(7)]
		public AchievementCriteriaConditionDefinition Fail { get; internal set; }

		[WireMember(8)]
		public LocalizedStringDBC<TStringType> Description { get; internal set; }

		[WireMember(9)]
		public AchievementFlags Flags { get; internal set; }

		[WireMember(10)]
		public AchievementCriteriaConditionDefinition Timed { get; internal set; }

		[WireMember(11)]
		public int Time { get; internal set; }

		[WireMember(12)]
		public int UIOrder { get; internal set; }

		public AchievementCriteriaEntry(int achievementCriteriaId, int referredAchievementId, [NotNull] AchievementEntry<TStringType> achievementEntry, AchievementCriteriaTypes type, int assetId, int amount, [NotNull] AchievementCriteriaConditionDefinition start, [NotNull] AchievementCriteriaConditionDefinition fail, [NotNull] LocalizedStringDBC<TStringType> description, AchievementFlags flags, [NotNull] AchievementCriteriaConditionDefinition timed, int time, int uiOrder)
		{
			if (!Enum.IsDefined(typeof(AchievementFlags), flags)) throw new InvalidEnumArgumentException(nameof(flags), (int) flags, typeof(AchievementFlags));

			AchievementCriteriaId = achievementCriteriaId;
			ReferredAchievementId = referredAchievementId;
			AchievementEntry = achievementEntry ?? throw new ArgumentNullException(nameof(achievementEntry));
			Type = type;
			AssetId = assetId;
			Amount = amount;
			Start = start ?? throw new ArgumentNullException(nameof(start));
			Fail = fail ?? throw new ArgumentNullException(nameof(fail));
			Description = description ?? throw new ArgumentNullException(nameof(description));
			Flags = flags;
			Timed = timed ?? throw new ArgumentNullException(nameof(timed));
			Time = time;
			UIOrder = uiOrder;
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public AchievementCriteriaEntry()
		{
			
		}
	}
}
