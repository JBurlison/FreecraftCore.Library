using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		public int EntryId => UnitBloodLevelId;

		[Key]
		[WireMember(1)]
		public int UnitBloodLevelId { get; internal set; }

		[WireMember(2)]
		public Vector3<int> ViolenceLevel { get; internal set; }

		public UnitBloodLevelsEntry(int unitBloodLevelId, [NotNull] Vector3<int> violenceLevel)
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

	public static class UnitBloodLevelsEntryExtensions
	{
		public static int GetViolenceLevel([NotNull] this UnitBloodLevelsEntry entry, Violencelevels level)
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));
			if (!Enum.IsDefined(typeof(Violencelevels), level)) throw new InvalidEnumArgumentException(nameof(level), (int) level, typeof(Violencelevels));

			return entry.ViolenceLevel[(int) level];
		}
	}
}
