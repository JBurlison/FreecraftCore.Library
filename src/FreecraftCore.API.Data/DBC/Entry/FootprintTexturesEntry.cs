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
	//FootprintTextures.dbc
	/// <summary>
	/// Table model for FootprintTextures.dbc
	/// https://wowdev.wiki/DB/FootprintTextures
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(FootprintTexturesEntry<>))]
	[Table("FootprintTextures")]
	public class FootprintTexturesEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => FootprintTextureId;

		[Key]
		[WireMember(1)]
		public int FootprintTextureId { get; private set; }

		/// <summary>
		/// Filename path of the footprint texture.
		/// </summary>
		[WireMember(2)]
		public TStringType FootstepFilename { get; private set; }

		public FootprintTexturesEntry(int footprintTextureId, [NotNull] TStringType footstepFilename)
		{
			if (footprintTextureId <= 0) throw new ArgumentOutOfRangeException(nameof(footprintTextureId));

			FootprintTextureId = footprintTextureId;
			FootstepFilename = footstepFilename ?? throw new ArgumentNullException(nameof(footstepFilename));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public FootprintTexturesEntry()
		{
			
		}
	}
}
