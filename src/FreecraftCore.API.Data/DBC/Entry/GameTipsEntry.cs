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
	//GameTips.dbc
	/// <summary>
	/// Table model for GameTips.dbc
	/// https://wowdev.wiki/DB/GameTips
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(GameTipsEntry<>))]
	[Table("GameTips")]
	public class GameTipsEntry<TStringType> : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public uint EntryId => (uint) GameTipId;

		[Key]
		[WireMember(1)]
		public int GameTipId { get; private set; }

		[WireMember(2)]
		public LocalizedStringDBC<TStringType> Tip { get; private set; }

		public GameTipsEntry(int gameTipId, [NotNull] LocalizedStringDBC<TStringType> tip)
		{
			if (gameTipId <= 0) throw new ArgumentOutOfRangeException(nameof(gameTipId));

			GameTipId = gameTipId;
			Tip = tip ?? throw new ArgumentNullException(nameof(tip));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public GameTipsEntry()
		{
			
		}
	}
}
