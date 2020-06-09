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
	[DBC]
	[StringDBC(typeof(MapEntry<>))]
	[WireDataContract]
	[JsonObject]
	[Table("Map")]
	public sealed class MapEntry<TStringType> : IDBCEntryIdentifiable
	{
		public static readonly string[] INTERNAL_FIELD_NAMES = new string[2] {nameof(PvP), nameof(ExpansionId)};

		/// <summary>
		/// The index.
		/// </summary>
		[NotMapped]
		[JsonIgnore]
		public int EntryId => MapId;

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)] //Blizzard fucked us and uses 0 as a map. MySQL does not support 0 insert https://bugs.mysql.com/bug.php?id=21465
		[WireMember(1)]
		public int MapId { get; internal set; }

		[WireMember(2)]
		public TStringType Directory { get; internal set; }

		[WireMember(3)]
		public MapTypes MapType { get; internal set; }

		[WireMember(4)]
		public AreaFlags Flags { get; internal set; }

		[WireMember(5)]
		internal int PvP { get; set; }

		[NotMapped]
		[JsonIgnore]
		public bool isPvPMap => PvP == 1;

		[WireMember(6)]
		public LocalizedStringDBC<TStringType> MapName { get; internal set; }

		//TODO: Nav prop to AreaTable.
		/// <summary>
		/// AreaTable.dbc reference.
		/// </summary>
		[WireMember(7)]
		public int AreaTableId { get; internal set; }

		[WireMember(8)]
		public LocalizedStringDBC<TStringType> MapDescription0 { get; internal set; }

		[WireMember(9)]
		public LocalizedStringDBC<TStringType> MapDescription1 { get; internal set; }

		[WireMember(10)]
		public int LoadingScreenId { get; internal set; }

		[WireMember(11)]
		public float MinimapIconScale { get; internal set; }

		[WireMember(12)]
		public int CorpseMapId { get; internal set; }

		[WireMember(13)]
		public Vector2<int> Corpse { get; internal set; }

		[WireMember(14)]
		public int TimeOfDayOverride { get; internal set; }

		[WireMember(15)]
		internal int ExpansionId { get; set; }

		[NotMapped]
		[JsonIgnore]
		public Expansions Expansion => (Expansions) ExpansionId;

		[WireMember(16)]
		public int RaidOffset { get; internal set; }

		[WireMember(17)]
		public int MaxPlayers { get; internal set; }

		public MapEntry(int mapId, TStringType directory, MapTypes mapType, AreaFlags flags, bool isPvPMap, LocalizedStringDBC<TStringType> mapName, int areaTableId, LocalizedStringDBC<TStringType> mapDescription0, LocalizedStringDBC<TStringType> mapDescription1, int loadingScreenId, float minimapIconScale, int corpseMapId, Vector2<int> corpse, int timeOfDayOverride, Expansions expansion, int raidOffset, int maxPlayers)
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
		public MapEntry()
		{

		}
	}
}
