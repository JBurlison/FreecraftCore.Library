using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//AreaTrigger.dbc
	/// <summary>
	/// Table model for Map.dbc
	/// https://wowdev.wiki/DB/Map
	/// </summary>
	[GenericDbcModel(typeof(MapEntry<StringDBCReference>), typeof(MapEntry<string>))]
	[WireDataContract]
	[JsonObject]
	[Table("Map")]
	public sealed class MapEntry<TStringType> : IDBCEntryIdentifiable
	{
		/// <summary>
		/// The index.
		/// </summary>
		[NotMapped]
		[JsonIgnore]
		public uint EntryId => (uint) MapId;

		[Key]
		[WireMember(1)]
		public int MapId { get; private set; }

		[WireMember(2)]
		public TStringType Directory { get; private set; }

		[WireMember(3)]
		public MapTypes MapType { get; private set; }

		[WireMember(4)]
		public AreaFlags Flags { get; private set; }

		[WireMember(5)]
		internal int PvP { get; private set; }

		[NotMapped]
		[JsonIgnore]
		public bool isPvPMap => PvP == 1;

		[WireMember(6)]
		public LocalizedStringDBC<TStringType> MapName { get; private set; }

		//TODO: Nav prop to AreaTable.
		/// <summary>
		/// AreaTable.dbc reference.
		/// </summary>
		[WireMember(7)]
		public int AreaTableId { get; private set; }

		[WireMember(8)]
		public LocalizedStringDBC<TStringType> MapDescription0 { get; private set; }

		[WireMember(9)]
		public LocalizedStringDBC<TStringType> MapDescription1 { get; private set; }

		[WireMember(10)]
		public int LoadingScreenId { get; private set; }

		[WireMember(11)]
		public float MinimapIconScale { get; private set; }

		[WireMember(12)]
		public int CorpseMapId { get; private set; }

		[WireMember(13)]
		public Vector2<int> Corpse { get; private set; }

		[WireMember(14)]
		public int TimeOfDayOverride { get; private set; }

		[WireMember(15)]
		internal int ExpansionId { get; private set; }

		[NotMapped]
		[JsonIgnore]
		public ExpansionType Expansion => (ExpansionType) ExpansionId;

		[WireMember(16)]
		public int RaidOffset { get; private set; }

		[WireMember(17)]
		public int MaxPlayers { get; private set; }

		public MapEntry(int mapId, TStringType directory, MapTypes mapType, AreaFlags flags, bool isPvPMap, LocalizedStringDBC<TStringType> mapName, int areaTableId, LocalizedStringDBC<TStringType> mapDescription0, LocalizedStringDBC<TStringType> mapDescription1, int loadingScreenId, float minimapIconScale, int corpseMapId, Vector2<int> corpse, int timeOfDayOverride, ExpansionType expansion, int raidOffset, int maxPlayers)
		{
			MapId = mapId;
			Directory = directory;
			MapType = mapType;
			Flags = flags;
			PvP = isPvPMap ? 1 : 0;
			MapName = mapName;
			AreaTableId = areaTableId;
			MapDescription0 = mapDescription0;
			MapDescription1 = mapDescription1;
			LoadingScreenId = loadingScreenId;
			MinimapIconScale = minimapIconScale;
			CorpseMapId = corpseMapId;
			Corpse = corpse;
			TimeOfDayOverride = timeOfDayOverride;
			ExpansionId = (int) expansion;
			RaidOffset = raidOffset;
			MaxPlayers = maxPlayers;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		private MapEntry()
		{

		}
	}
}
