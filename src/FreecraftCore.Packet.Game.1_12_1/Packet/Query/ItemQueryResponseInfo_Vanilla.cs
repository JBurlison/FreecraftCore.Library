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
		public ItemClassType ClassType { get; }

		/// <summary>
		/// The subclass type.
		/// Related to the <see cref="ClassType"/>
		/// </summary>
		[WireMember(2)]
		public int SubClassType { get; }

		[KnownSize(4)]
		[WireMember(4)]
		public string[] ItemNames { get; }

		[WireMember(5)]
		public int DisplayId { get; }

		[WireMember(6)]
		public ItemQuality Quality { get; }

		/// <summary>
		/// TODO: Is this same flags as 3.3.5?
		/// </summary>
		[WireMember(7)]
		public ItemFlags ItemFlags { get; }

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

		//TODO: Mangos warns: (pProto->RequiredReputationFaction > 0  ? pProto->RequiredReputationRank : 0);   // send value only if reputation faction id setted ( needed for some items)
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

		[KnownSize(10)] //static size on 1.2.1
		[WireMember(26)]
		public StatInfo[] StatInfos { get; }

		[KnownSize(5)] //5 on 1.12.1 instead of 2 on 3.3.5
		[WireMember(29)]
		public ItemDamageDefinition[] ItemDamageMods { get; }

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

		[KnownSize(5)] //same on 3.3.5
		[WireMember(34)]
		public ItemSpellInfo[] SpellInfos { get; }

		[WireMember(35)]
		public ItemBondingType BondingType { get; }

		[Encoding(EncodingType.ASCII)]
		[WireMember(36)]
		public string ItemDescription { get; }

		//This is an int, not a string.
		[WireMember(37)]
		public int PageText { get; }

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
