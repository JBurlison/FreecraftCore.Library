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
	//ObjectEffectPackage.dbc
	/// <summary>
	/// Table model for ObjectEffectPackage.dbc
	/// https://wowdev.wiki/DB/ObjectEffectPackage
	/// Purely descriptive table.
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(ObjectEffectPackageEntry<>))]
	[Table("ObjectEffectPackage")]
	public class ObjectEffectPackageEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => ObjectEffectPackageId;

		[Key]
		[WireMember(1)]
		public int ObjectEffectPackageId { get; private set; }

		[WireMember(2)]
		public TStringType Name { get; private set; }

		public ObjectEffectPackageEntry(int objectEffectPackageId, [NotNull] TStringType name)
		{
			if (objectEffectPackageId <= 0) throw new ArgumentOutOfRangeException(nameof(objectEffectPackageId));

			ObjectEffectPackageId = objectEffectPackageId;
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public ObjectEffectPackageEntry()
		{
			
		}
	}
}
