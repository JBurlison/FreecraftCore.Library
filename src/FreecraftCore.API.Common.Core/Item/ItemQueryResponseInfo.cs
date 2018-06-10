using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	//TODO: Refactor this, it's TERRIBLE!
	public sealed class ItemQueryResponseInfo
	{
		[WireMember(1)]
		public ItemClassType ClassType { get; }

		/// <summary>
		/// The subclass type.
		/// Related to the <see cref="ClassType"/>
		/// </summary>
		[WireMember(2)]
		public int SubClassType { get; }

		/// <summary>
		/// TODO: What is this?
		/// </summary>
		[WireMember(3)]
		public int SoundOverrideSubclass { get; }

		[KnownSize(4)]
		[WireMember(4)]
		public string[] ItemNames { get; }

		[WireMember(5)]
		public int DisplayId { get; }

		[WireMember(6)]
		public ItemQuality Quality { get; }

		/// <summary>
		/// TODO: Find the flags enum for this
		/// </summary>
		[WireMember(7)]
		public ItemFlags ItemFlags { get; }

		//1.12.1 does not send an extra flag.
		/// <summary>
		/// TODO: Find the flags enum for this.
		/// </summary>
		[WireMember(8)]
		public ItemFlags2 ItemFlags2 { get; }

		[WireMember(9)]
		public int BuyPrice { get; }

		[WireMember(10)]
		public int SellPrice { get; }

		//TODO: Enum
		[WireMember(11)]
		public int InventoryType { get; }

		/// <summary>
		/// Indicates an allowable class.
		/// </summary>
		[WireMember(12)]
		public uint AllowableClass { get; }

		[WireMember(13)]
		public int AllowableRace { get; }

		[WireMember(14)]
		public int ItemLevel { get; }

		[WireMember(15)]
		public int RequiredLevel { get; }

		[WireMember(16)]
		public int RequiredSkill { get; }

		[WireMember(17)]
		public int RequiredSkillRank { get; }

		[WireMember(18)]
		public int RequiredSpell { get; }

		[WireMember(19)]
		public int RequiredHonorRank { get; }

		[WireMember(20)]
		public int RequiredCityRank { get; }

		[WireMember(21)]
		public int RequiredReptuationFaction { get; }

		[WireMember(22)]
		public int RequiredReptuationRank { get; }

		[WireMember(23)]
		public int MaxCount { get; }

		[WireMember(24)]
		public int MaxStackable { get; }

		[WireMember(25)]
		public int ContainerSlots { get; }

		[SendSize(SendSizeAttribute.SizeType.Int32)]
		[WireMember(26)]
		public StatInfo[] StatInfos { get; }

		[WireMember(27)]
		public int ScalingStatDistribution { get; }

		[WireMember(28)]
		public int ScalingStatValue { get; }

		[KnownSize(2)]
		[WireMember(29)]
		public ItemDamageDefition[] ItemDamageMods { get; }

		//See: SpellSchools enumeration
		[KnownSize(7)]
		[WireMember(30)]
		public int[] Resistances { get; }

		[WireMember(31)]
		public int Delay { get; }

		[WireMember(32)]
		public int AmmoType { get; }

		[WireMember(33)]
		public float RangedModRange { get; }

		[KnownSize(5)]
		[WireMember(34)]
		public ItemSpellInfo[] SpellInfos { get; }

		[WireMember(35)]
		public ItemBondingType BondingType { get; }

		[Encoding(EncodingType.ASCII)]
		[WireMember(36)]
		public string ItemDescription { get; }

		[Encoding(EncodingType.ASCII)]
		[WireMember(37)]
		public string PageText { get; }

		[WireMember(38)]
		public int LanguageId { get; }

		[WireMember(39)]
		public int PageMaterial { get; }

		[WireMember(40)]
		public int StartQuest { get; }

		[WireMember(41)]
		public int LockID { get; }

		[WireMember(42)]
		public int Material { get; }

		[WireMember(43)]
		public int Sheath { get; }

		[WireMember(44)]
		public int RandomProperty { get; }

		[WireMember(45)]
		public int RandomSuffix { get; }

		[WireMember(46)]
		public int Block { get; }

		[WireMember(47)]
		public int ItemSet { get; }

		[WireMember(48)]
		public int Maxdurability { get; }

		[WireMember(49)]
		public int Area { get; }

		[WireMember(50)]
		public int Map { get; }

		[WireMember(51)]
		public BAG_FAMILY_MASK BagFamily { get; }

		[WireMember(52)]
		public ItemSocketInfo SocketInformation { get; }

		[WireMember(53)]
		public int RequiredDisenchantSkill { get; }

		[WireMember(54)]
		public int ArmorDamageModifier { get; }

		[WireMember(55)]
		public int Duration { get; }

		[WireMember(56)]
		public int ItemLimitCategory { get; }

		[WireMember(57)]
		public int HolidayId { get; }

		/// <inheritdoc />
		public ItemQueryResponseInfo(ItemClassType classType, int subClassType, int soundOverrideSubclass, string[] itemNames, int displayId, ItemQuality quality, ItemFlags itemFlags, ItemFlags2 itemFlags2, int buyPrice, int sellPrice, int inventoryType, uint allowableClass, int allowableRace, int itemLevel, int requiredLevel, int requiredSkill, int requiredSkillRank, int requiredSpell, int requiredHonorRank, int requiredCityRank, int requiredReptuationFaction, int requiredReptuationRank, int maxCount, int maxStackable, int containerSlots, StatInfo[] statInfos, int scalingStatDistribution, int scalingStatValue, ItemDamageDefition[] itemDamageMods, int[] resistances, int delay, int ammoType, float rangedModRange, ItemSpellInfo[] spellInfos, ItemBondingType bondingType, string itemDescription, string pageText, int languageId, int pageMaterial, int startQuest, int lockId, int material, int sheath, int randomProperty, int randomSuffix, int block, int itemSet, int maxdurability, int area, int map, BAG_FAMILY_MASK bagFamily, ItemSocketInfo socketInformation, int requiredDisenchantSkill, int armorDamageModifier, int duration, int itemLimitCategory, int holidayId)
		{
			ClassType = classType;
			SubClassType = subClassType;
			SoundOverrideSubclass = soundOverrideSubclass;
			ItemNames = itemNames;
			DisplayId = displayId;
			Quality = quality;
			ItemFlags = itemFlags;
			ItemFlags2 = itemFlags2;
			BuyPrice = buyPrice;
			SellPrice = sellPrice;
			InventoryType = inventoryType;
			AllowableClass = allowableClass;
			AllowableRace = allowableRace;
			ItemLevel = itemLevel;
			RequiredLevel = requiredLevel;
			RequiredSkill = requiredSkill;
			RequiredSkillRank = requiredSkillRank;
			RequiredSpell = requiredSpell;
			RequiredHonorRank = requiredHonorRank;
			RequiredCityRank = requiredCityRank;
			RequiredReptuationFaction = requiredReptuationFaction;
			RequiredReptuationRank = requiredReptuationRank;
			MaxCount = maxCount;
			MaxStackable = maxStackable;
			ContainerSlots = containerSlots;
			StatInfos = statInfos;
			ScalingStatDistribution = scalingStatDistribution;
			ScalingStatValue = scalingStatValue;
			ItemDamageMods = itemDamageMods;
			Resistances = resistances;
			Delay = delay;
			AmmoType = ammoType;
			RangedModRange = rangedModRange;
			SpellInfos = spellInfos;
			BondingType = bondingType;
			ItemDescription = itemDescription;
			PageText = pageText;
			LanguageId = languageId;
			PageMaterial = pageMaterial;
			StartQuest = startQuest;
			LockID = lockId;
			Material = material;
			Sheath = sheath;
			RandomProperty = randomProperty;
			RandomSuffix = randomSuffix;
			Block = block;
			ItemSet = itemSet;
			Maxdurability = maxdurability;
			Area = area;
			Map = map;
			BagFamily = bagFamily;
			SocketInformation = socketInformation;
			RequiredDisenchantSkill = requiredDisenchantSkill;
			ArmorDamageModifier = armorDamageModifier;
			Duration = duration;
			ItemLimitCategory = itemLimitCategory;
			HolidayId = holidayId;
		}

		protected ItemQueryResponseInfo()
		{
			
		}
	}
}
