using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class ItemQueryResponseInfo_Vanilla
	{
		[WireMember(1)]
		public ItemClassType ClassType { get; internal set; }

		/// <summary>
		/// The subclass type.
		/// Related to the <see cref="ClassType"/>
		/// </summary>
		[WireMember(2)]
		public int SubClassType { get; internal set; }

		[KnownSize(4)]
		[WireMember(4)]
		public string[] ItemNames { get; internal set; }

		[WireMember(5)]
		public int DisplayId { get; internal set; }

		[WireMember(6)]
		public ItemQuality Quality { get; internal set; }

		/// <summary>
		/// TODO: Is this same flags as 3.3.5?
		/// </summary>
		[WireMember(7)]
		public ItemFlags ItemFlags { get; internal set; }

		[WireMember(9)]
		public int BuyPrice { get; internal set; }

		[WireMember(10)]
		public int SellPrice { get; internal set; }

		//TODO: Enum
		[WireMember(11)]
		public int InventoryType { get; internal set; }

		/// <summary>
		/// Indicates an allowable class.
		/// </summary>
		[WireMember(12)]
		public uint AllowableClass { get; internal set; }

		[WireMember(13)]
		public int AllowableRace { get; internal set; }

		[WireMember(14)]
		public int ItemLevel { get; internal set; }

		[WireMember(15)]
		public int RequiredLevel { get; internal set; }

		[WireMember(16)]
		public int RequiredSkill { get; internal set; }

		[WireMember(17)]
		public int RequiredSkillRank { get; internal set; }

		[WireMember(18)]
		public int RequiredSpell { get; internal set; }

		[WireMember(19)]
		public int RequiredHonorRank { get; internal set; }

		[WireMember(20)]
		public int RequiredCityRank { get; internal set; }

		//TODO: Mangos warns: (pProto->RequiredReputationFaction > 0  ? pProto->RequiredReputationRank : 0);   // send value only if reputation faction id setted ( needed for some items)
		[WireMember(21)]
		public int RequiredReptuationFaction { get; internal set; }

		[WireMember(22)]
		public int RequiredReptuationRank { get; internal set; }

		[WireMember(23)]
		public int MaxCount { get; internal set; }

		[WireMember(24)]
		public int MaxStackable { get; internal set; }

		[WireMember(25)]
		public int ContainerSlots { get; internal set; }

		[KnownSize(10)] //static size on 1.2.1
		[WireMember(26)]
		public StatInfo[] StatInfos { get; internal set; }

		[KnownSize(5)] //5 on 1.12.1 instead of 2 on 3.3.5
		[WireMember(29)]
		public ItemDamageDefinition[] ItemDamageMods { get; internal set; }

		//See: SpellSchools enumeration
		[KnownSize(7)]
		[WireMember(30)]
		public int[] Resistances { get; internal set; }

		[WireMember(31)]
		public int Delay { get; internal set; }

		[WireMember(32)]
		public int AmmoType { get; internal set; }

		[WireMember(33)]
		public float RangedModRange { get; internal set; }

		[KnownSize(5)] //same on 3.3.5
		[WireMember(34)]
		public ItemSpellInfo[] SpellInfos { get; internal set; }

		[WireMember(35)]
		public ItemBondingType BondingType { get; internal set; }

		[Encoding(EncodingType.ASCII)]
		[WireMember(36)]
		public string ItemDescription { get; internal set; }

		//This is an int, not a string.
		[WireMember(37)]
		public int PageText { get; internal set; }

		[WireMember(38)]
		public int LanguageId { get; internal set; }

		[WireMember(39)]
		public int PageMaterial { get; internal set; }

		[WireMember(40)]
		public int StartQuest { get; internal set; }

		[WireMember(41)]
		public int LockID { get; internal set; }

		[WireMember(42)]
		public int Material { get; internal set; }

		[WireMember(43)]
		public int Sheath { get; internal set; }

		[WireMember(44)]
		public int RandomProperty { get; internal set; }

		[WireMember(46)]
		public int Block { get; internal set; }

		[WireMember(47)]
		public int ItemSet { get; internal set; }

		[WireMember(48)]
		public int Maxdurability { get; internal set; }

		[WireMember(49)]
		public int Area { get; internal set; }

		[WireMember(50)]
		public int Map { get; internal set; }

		[WireMember(51)]
		public BAG_FAMILY_MASK BagFamily { get; internal set; }

		/// <inheritdoc />
		public ItemQueryResponseInfo_Vanilla(ItemClassType classType, int subClassType, string[] itemNames, int displayId, ItemQuality quality, ItemFlags itemFlags, int buyPrice, int sellPrice, int inventoryType, uint allowableClass, int allowableRace, int itemLevel, int requiredLevel, int requiredSkill, int requiredSkillRank, int requiredSpell, int requiredHonorRank, int requiredCityRank, int requiredReptuationFaction, int requiredReptuationRank, int maxCount, int maxStackable, int containerSlots, StatInfo[] statInfos, ItemDamageDefinition[] itemDamageMods, int[] resistances, int delay, int ammoType, float rangedModRange, ItemSpellInfo[] spellInfos, ItemBondingType bondingType, string itemDescription, int pageText, int languageId, int pageMaterial, int startQuest, int lockId, int material, int sheath, int randomProperty, int block, int itemSet, int maxdurability, int area, int map, BAG_FAMILY_MASK bagFamily)
		{
			ClassType = classType;
			SubClassType = subClassType;
			ItemNames = itemNames;
			DisplayId = displayId;
			Quality = quality;
			ItemFlags = itemFlags;
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
			Block = block;
			ItemSet = itemSet;
			Maxdurability = maxdurability;
			Area = area;
			Map = map;
			BagFamily = bagFamily;
		}

		protected ItemQueryResponseInfo_Vanilla()
		{
			
		}
	}
}
