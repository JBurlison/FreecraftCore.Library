using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class GroupSettingsData
	{
		[WireMember(1)]
		public LootMethod LootmodeSetting { get; internal set; }

		//Only set if LootMethod == MASTER_LOOT but always still sent for some reason.
		[WireMember(2)]
		public ObjectGuid LootMasterGuid { get; internal set; }

		//We can't use the enum directly since other packets consider it an int
		[WireMember(3)]
		internal byte _LootQualityThreshold { get; set; }

		/// <summary>
		/// The quality threshold for the loot to be rolled.
		/// </summary>
		public ItemQuality LootQualityThreshold => (ItemQuality)_LootQualityThreshold;

		[WireMember(4)]
		public Difficulty DungeonDifficulty { get; internal set; }

		[WireMember(5)]
		public Difficulty RaidDifficulty { get; internal set; }

		//Cannot understand what this is or means
		//data << uint8(m_raidDifficulty >= RAID_DIFFICULTY_10MAN_HEROIC);    // 3.3 Dynamic Raid Difficulty - 0 normal/1 heroic
		[WireMember(6)]
		public bool Unk1 { get; internal set; }

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public GroupSettingsData()
		{
			
		}
	}
}
