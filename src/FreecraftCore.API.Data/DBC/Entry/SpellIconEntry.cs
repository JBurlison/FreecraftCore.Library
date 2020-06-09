using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Numerics;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//SpellIcon.dbc
	/// <summary>
	/// Table model for SpellIcon.dbc
	/// https://wowdev.wiki/DB/SpellIcon
	/// Not only for spells.
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(SpellIconEntry<>))]
	[Table("SpellIcon")]
	public class SpellIconEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => IconId;

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[WireMember(1)]
		public int IconId { get; internal set; }

		/// <summary>
		/// There are no extensions (.blp) in these. They mostly match "Interface\Icons\[a-z_0-9]" but there are exceptions.
		/// </summary>
		[WireMember(2)]
		public TStringType TextureFileName { get; internal set; }

		public SpellIconEntry(int iconId, [NotNull] TStringType textureFileName)
		{
			if (iconId <= 0) throw new ArgumentOutOfRangeException(nameof(iconId));

			IconId = iconId;
			TextureFileName = textureFileName ?? throw new ArgumentNullException(nameof(textureFileName));
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public SpellIconEntry()
		{
			
		}
	}
}
