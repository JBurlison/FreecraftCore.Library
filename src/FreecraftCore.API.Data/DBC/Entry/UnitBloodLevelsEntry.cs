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
	//UnitBloodLevels.dbc
	[DBC]
	[WireDataContract]
	[JsonObject]
	[Table("UnitBloodLevels")]
	public sealed class UnitBloodLevelsEntry : IDBCEntryIdentifiable
	{
		/// <inheritdoc />
		[JsonIgnore]
		public uint EntryId => (uint)UnitBloodLevelId;

		[Key]
		[WireMember(1)]
		public int UnitBloodLevelId { get; private set; }

		[WireMember(2)]
		public Vector3<Violencelevels> ViolenceLevel { get; private set; }

		public UnitBloodLevelsEntry(int unitBloodLevelId, [NotNull] Vector3<Violencelevels> violenceLevel)
		{
			UnitBloodLevelId = unitBloodLevelId;
			ViolenceLevel = violenceLevel ?? throw new ArgumentNullException(nameof(violenceLevel));
		}

		/// <summary>
		/// Serializer ctor
		/// </summary>
		public UnitBloodLevelsEntry()
		{
			
		}
	}
}
