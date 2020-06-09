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
	//SpellItemEnchantment.dbc
	/// <summary>
	/// Table model for SpellItemEnchantment.dbc
	/// https://wowdev.wiki/DB/SpellItemEnchantment
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(SpellItemEnchantmentEntry<>))]
	[Table("SpellItemEnchantment")]
	public sealed class SpellItemEnchantmentEntry<TStringType> : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => EnchantmentId;

		[Key]
		[WireMember(1)]
		public int EnchantmentId { get; internal set; }

		[WireMember(2)]
		public int Charges { get; internal set; }

		[Column("Effect")]
		[WireMember(3)]
		public ItemEnchantmentSpellCollection Effects { get; internal set; }

		[WireMember(4)]
		public LocalizedStringDBC<TStringType> Description { get; internal set; }

		[WireMember(5)]
		public int ItemVisual { get; internal set; }

		[WireMember(6)]
		public EnchantmentSlotMask Flags { get; internal set; }

		[WireMember(7)]
		public int GemItemId { get; internal set; }

		[WireMember(8)]
		public int EnchantmentConditionId { get; internal set; }

		[WireMember(9)]
		public int RequiredSkillId { get; internal set; }

		[WireMember(10)]
		public int RequiredSkillValue { get; internal set; }

		[WireMember(11)]
		public int RequiredLevel { get; internal set; }

		public SpellItemEnchantmentEntry(int enchantmentId, int charges, [NotNull] ItemEnchantmentSpellCollection effects, [NotNull] LocalizedStringDBC<TStringType> description, int itemVisual, EnchantmentSlotMask flags, int gemItemId, int enchantmentConditionId, int requiredSkillId, int requiredSkillValue, int requiredLevel)
		{
			EnchantmentId = enchantmentId;
			Charges = charges;
			Effects = effects ?? throw new ArgumentNullException(nameof(effects));
			Description = description ?? throw new ArgumentNullException(nameof(description));
			ItemVisual = itemVisual;
			Flags = flags;
			GemItemId = gemItemId;
			EnchantmentConditionId = enchantmentConditionId;
			RequiredSkillId = requiredSkillId;
			RequiredSkillValue = requiredSkillValue;
			RequiredLevel = requiredLevel;
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public SpellItemEnchantmentEntry()
		{
			
		}
	}
}
