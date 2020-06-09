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
	//Achievement.dbc
	/// <summary>
	/// Table model for Achievement.dbc
	/// https://wowdev.wiki/DB/Achievement
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(AchievementEntry<>))]
	[Table("Achievement")]
	public sealed class AchievementEntry<TStringType> : IDBCEntryIdentifiable, IDBCUIOrderable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => AchievementId;

		[Key]
		[WireMember(1)]
		public int AchievementId { get; internal set; }

		[WireMember(2)]
		public AchievementFaction Faction { get; internal set; }

		[WireMember(3)]
		public int MapId { get; internal set; }

		//TODO: nav property to AchievementEntry.
		/// <summary>
		/// its Achievement parent (can`t start while parent uncomplete, use its Criteria if don`t have own, use its progress on begin)
		/// </summary>
		[WireMember(4)]
		public int SupersedesId { get; internal set; }

		[WireMember(5)]
		public LocalizedStringDBC<TStringType> Title { get; internal set; }

		[WireMember(6)]
		public LocalizedStringDBC<TStringType> Description { get; internal set; }

		//TODO: Nav prop to category DBC
		[WireMember(7)]
		public int CategoryID { get; internal set; }

		[WireMember(8)]
		public int Points { get; internal set; }

		[WireMember(9)]
		public int UIOrder { get; internal set; }

		[WireMember(10)]
		public AchievementFlags Flags { get; internal set; }

		//TODO: Nav prop to Icon dbc.
		[WireMember(11)]
		public int IconId { get; internal set; }

		[WireMember(12)]
		public LocalizedStringDBC<TStringType> Reward { get; internal set; }

		[WireMember(13)]
		public int MinimumCriteriaCount { get; internal set; }

		/// <summary>
		/// The ID of the <see cref="AchievementEntry{TStringType}"/> that this achievement
		/// shares <see cref="MinimumCriteriaCount"/> with.
		/// </summary>
		[WireMember(14)]
		public int SharesCriteriaId { get; internal set; }

		public AchievementEntry(int achievementId, AchievementFaction faction, int mapId, int supersedesId, [NotNull] LocalizedStringDBC<TStringType> title, [NotNull] LocalizedStringDBC<TStringType> description, int categoryId, int points, int uiOrder, AchievementFlags flags, int iconId, [NotNull] LocalizedStringDBC<TStringType> reward, int minimumCriteriaCount, int sharesCriteriaId)
		{
			AchievementId = achievementId;
			Faction = faction;
			MapId = mapId;
			SupersedesId = supersedesId;
			Title = title ?? throw new ArgumentNullException(nameof(title));
			Description = description ?? throw new ArgumentNullException(nameof(description));
			CategoryID = categoryId;
			Points = points;
			UIOrder = uiOrder;
			Flags = flags;
			IconId = iconId;
			Reward = reward ?? throw new ArgumentNullException(nameof(reward));
			MinimumCriteriaCount = minimumCriteriaCount;
			SharesCriteriaId = sharesCriteriaId;
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public AchievementEntry()
		{
			
		}
	}
}
