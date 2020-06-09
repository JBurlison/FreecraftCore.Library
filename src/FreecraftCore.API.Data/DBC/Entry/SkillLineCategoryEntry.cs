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
	//SkillLineCategory.dbc
	/// <summary>
	/// Table model for SkillLineCategory.dbc
	/// https://wowdev.wiki/DB/SkillLineCategory
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(SkillLineCategoryEntry<>))]
	[Table("SkillLineCategory")]
	public sealed class SkillLineCategoryEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		/// <inheritdoc />
		[JsonIgnore]
		[NotMapped]
		public int EntryId => CategoryId;

		[Key]
		[WireMember(1)]
		public int CategoryId { get; internal set; }

		[WireMember(2)]
		public LocalizedStringDBC<TStringType> Name { get; internal set; }

		/// <summary>
		/// DisplayOrder
		/// </summary>
		[WireMember(3)]
		public int SortIndex { get; internal set; }

		public SkillLineCategoryEntry(int categoryId, [NotNull] LocalizedStringDBC<TStringType> name, int sortIndex)
		{
			if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));
			if (sortIndex <= 0) throw new ArgumentOutOfRangeException(nameof(sortIndex));

			CategoryId = categoryId;
			Name = name ?? throw new ArgumentNullException(nameof(name));
			SortIndex = sortIndex;
		}

		/// <summary>
		/// serializer ctor
		/// </summary>
		public SkillLineCategoryEntry()
		{
			
		}
	};
}
