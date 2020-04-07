﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//Achievement_Category.dbc
	/// <summary>
	/// Table model for Achievement_Category.dbc
	/// https://wowdev.wiki/DB/Achievement_Category
	/// </summary>
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(AchievementCategory<>))]
	[Table("Achievement_Category")]
	public sealed class AchievementCategory<TStringType> : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public uint EntryId => (uint)AchievementCategoryId;

		[Key]
		[WireMember(1)]
		public int AchievementCategoryId { get; private set; }

		//TODO: nav property
		[WireMember(2)]
		public int ParentId { get; private set; }

		[WireMember(3)]
		public LocalizedStringDBC<TStringType> Name { get; private set; }

		[WireMember(4)]
		public int UIOrder { get; private set; }

		public AchievementCategory(int achievementCategoryId, int parentId, [NotNull] LocalizedStringDBC<TStringType> name, int uiOrder)
		{
			AchievementCategoryId = achievementCategoryId;
			ParentId = parentId;
			Name = name ?? throw new ArgumentNullException(nameof(name));
			UIOrder = uiOrder;
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public AchievementCategory()
		{
			
		}
	}
}
