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
		public LootMethod LootmodeSetting { get; private set; }

		//Only set if LootMethod == MASTER_LOOT but always still sent for some reason.
		[WireMember(2)]
		public ObjectGuid LootMasterGuid { get; private set; }

		//We can't use the enum directly since other packets consider it an int
		[WireMember(3)]
		private byte _LootQualityThreshold { get; set; }

		/// <summary>
		/// The quality threshold for the loot to be rolled.
		/// </summary>
		public ItemQuality LootQualityThreshold => (ItemQuality)_LootQualityThreshold;

		[WireMember(4)]
		public Difficulty DungeonDifficulty { get; private set; }

		[WireMember(5)]
		public Difficulty RaidDifficulty { get; private set; }

		//Cannot understand what this is or means
		//data << uint8(m_raidDifficulty >= RAID_DIFFICULTY_10MAN_HEROIC);    // 3.3 Dynamic Raid Difficulty - 0 normal/1 heroic
		[WireMember(6)]
		public bool Unk1 { get; private set; }

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public GroupSettingsData()
		{
			
		}
	}
}
