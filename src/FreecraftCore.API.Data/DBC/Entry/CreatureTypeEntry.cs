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
	//CreatureType.dbc
	/// <summary>
	/// Table model for CreatureType.dbc
	/// https://wowdev.wiki/DB/CreatureType
	/// If changes are made then <see cref="ChatLanguage"/> must be updated.
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(CreatureTypeEntry<>))]
	[Table("CreatureType")]
	public class CreatureTypeEntry<TStringType> : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public uint EntryId => (uint) CreatureTypeId;

		[Key]
		[WireMember(1)]
		public int CreatureTypeId { get; private set; }

		[WireMember(2)]
		public LocalizedStringDBC<TStringType> Name { get; private set; }

		[WireMember(3)]
		public CreatureTypeDefinitionFlags Flags { get; private set; }

		public CreatureTypeEntry(int creatureTypeId, [NotNull] LocalizedStringDBC<TStringType> name, CreatureTypeDefinitionFlags flags)
		{
			if (creatureTypeId <= 0) throw new ArgumentOutOfRangeException(nameof(creatureTypeId));

			CreatureTypeId = creatureTypeId;
			Name = name ?? throw new ArgumentNullException(nameof(name));
			Flags = flags;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public CreatureTypeEntry()
		{
			
		}
	}

	public static class CreatureTypeEntryExtensions
	{
		/// <summary>
		/// Indicates if the creature type <see cref="CreatureTypeEntry{TStringType}"/> <see cref="entry"/>
		/// is able to reward experience.
		/// </summary>
		/// <typeparam name="TStringType">String type.</typeparam>
		/// <param name="entry">The creature type entry.</param>
		/// <returns>True if the creature type can reward experience.</returns>
		public static bool IsExperienceRewardable<TStringType>([NotNull] this CreatureTypeEntry<TStringType> entry)
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			return !entry.Flags.HasFlag(CreatureTypeDefinitionFlags.NoExperience);
		}

		public static CreatureType ToCreatureTypeEnum<TStringType>([NotNull] this CreatureTypeEntry<TStringType> entry)
		{
			if(entry == null) throw new ArgumentNullException(nameof(entry));

			return (CreatureType) entry.CreatureTypeId;
		}
	}
}
