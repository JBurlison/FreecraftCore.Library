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
	//SkillLine.dbc
	/// <summary>
	/// Table model for SkillLine.dbc
	/// https://wowdev.wiki/DB/SkillLine
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(SkillLineEntry<>))]
	[Table("SkillLine")]
	public class SkillLineEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		public static readonly string[] INTERNAL_FIELD_NAMES = new string[1] { nameof(CanLink) };

		/// <inheritdoc />
		[JsonIgnore]
		[NotMapped]
		public uint EntryId => (uint) SkillLineId;

		[Key]
		[WireMember(1)]
		public int SkillLineId { get; private set; }

		/// <summary>
		/// Non-nullable
		/// See: <see cref="SkillCategoryEntry{TStringType}"/>
		/// </summary>
		[WireMember(2)]
		public int CategoryId { get; private set; }

		[JsonIgnore]
		[ForeignKey(nameof(CategoryId))]
		public virtual SkillLineCategoryEntry<TStringType> Category { get; private set; }
		
		/// <summary>
		/// Nullable.
		/// TODO: Which DBC does this point too?
		/// </summary>
		[WireMember(3)]
		public int SkillCostId { get; private set; }

		[WireMember(4)]
		public LocalizedStringDBC<TStringType> DisplayName { get; private set; }

		[WireMember(5)]
		public LocalizedStringDBC<TStringType> Description { get; private set; }

		/// <summary>
		/// Nullable
		/// See: <see cref="SpellIconEntry{TStringType}"/>
		/// </summary>
		[WireMember(6)]
		public int SpellIconId { get; private set; }

		[WireMember(7)]
		public LocalizedStringDBC<TStringType> AlternativeVerb { get; private set; }

		/// <summary>
		/// prof. with recipes
		/// </summary>
		[Column("CanLink")]
		[JsonProperty(PropertyName = "CanLink")]
		[WireMember(8)]
		internal int CanLink { get; private set; }

		public SkillLineEntry(int skillLineId, int categoryId, int skillCostId, [NotNull] LocalizedStringDBC<TStringType> displayName, [NotNull] LocalizedStringDBC<TStringType> description, int spellIconId, [NotNull] LocalizedStringDBC<TStringType> alternativeVerb, bool canLink)
		{
			if (skillLineId <= 0) throw new ArgumentOutOfRangeException(nameof(skillLineId));
			if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId));

			SkillLineId = skillLineId;
			CategoryId = categoryId;
			SkillCostId = skillCostId;
			DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
			Description = description ?? throw new ArgumentNullException(nameof(description));
			SpellIconId = spellIconId;
			AlternativeVerb = alternativeVerb ?? throw new ArgumentNullException(nameof(alternativeVerb));
			CanLink = canLink ? 1 : 0;
		}

		/// <summary>
		/// serializer ctor
		/// </summary>
		public SkillLineEntry()
		{
			
		}
	};

	public static class SkillLineEntryExtensions
	{
		/// <summary>
		/// Indicates if the skill can be linked.
		/// </summary>
		/// <typeparam name="TStringType"></typeparam>
		/// <param name="entry"></param>
		/// <returns></returns>
		public static bool IsLinkable<TStringType>([NotNull] this SkillLineEntry<TStringType> entry)
			where TStringType : class
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			return entry.CanLink > 0;
		}
	}
}
