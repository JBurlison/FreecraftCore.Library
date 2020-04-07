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
	//Achievement_Criteria.dbc
	/// <summary>
	/// Table model for Achievement_Criteria.dbc
	/// https://wowdev.wiki/DB/Achievement_Category
	/// </summary>
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(AchievementCriteriaEntry<>))]
	[Table("Achievement_Criteria")]
	public class AchievementCriteriaEntry<TStringType> : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public uint EntryId => (uint)AchievementCriteriaId;

		[Key]
		[WireMember(1)]
		public int AchievementCriteriaId { get; private set; }

		/// <summary>
		/// The referenced achievement id.
		/// </summary>
		[WireMember(2)]
		public int ReferredAchievementId { get; private set; }

		[JsonIgnore]
		[ForeignKey(nameof(ReferredAchievementId))]
		public virtual AchievementEntry<TStringType> AchievementEntry { get; private set; }

		[WireMember(3)]
		public AchievementCriteriaTypes Type { get; private set; }

		//See TC DBC implementation to understand these.
		[WireMember(4)]
		public int AssetId { get; private set; }

		[WireMember(5)]
		public int Amount { get; private set; }

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public AchievementCriteriaEntry()
		{
			
		}
	}
}
