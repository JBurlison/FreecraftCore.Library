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
	//FactionGroup.dbc
	/// <summary>
	/// Table model for FactionGroup.dbc
	/// https://wowdev.wiki/DB/FactionGroup
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(FactionGroupEntry<>))]
	[Table("FactionGroup")]
	public class FactionGroupEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => FactionGroupId;

		[Key]
		[WireMember(1)]
		public int FactionGroupId { get; internal set; }

		[WireMember(2)]
		public int MaskId { get; internal set; }

		/// <summary>
		/// Unlocalized internal name for the faction group.
		/// </summary>
		[WireMember(3)]
		public TStringType InternalName { get; internal set; }

		/// <summary>
		/// The name of the faction.
		/// </summary>
		[WireMember(4)]
		public LocalizedStringDBC<TStringType> Name { get; internal set; }

		public FactionGroupEntry(int factionGroupId, [NotNull] TStringType internalName, [NotNull] LocalizedStringDBC<TStringType> name)
		{
			if (factionGroupId <= 0) throw new ArgumentOutOfRangeException(nameof(factionGroupId));

			FactionGroupId = factionGroupId;
			InternalName = internalName ?? throw new ArgumentNullException(nameof(internalName));
			Name = name ?? throw new ArgumentNullException(nameof(name));
			MaskId = factionGroupId - 1;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public FactionGroupEntry()
		{
			
		}
	}
}
