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
	public static class FactionEntryExtensions
	{
		/// <summary>
		/// Indicates if a player can gain reputation with the faction.
		/// </summary>
		/// <typeparam name="TStringType">String type.</typeparam>
		/// <param name="entry">The faction entry.</param>
		/// <returns>True if the player can gain reputation with the faction.</returns>
		public static bool IsReputationGainable<TStringType>([NotNull] this FactionEntry<TStringType> entry)
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			//From dev wiki: Each faction that has gainable rep has a unique number. All factions that you can not gain rep with have -1. Max value 127.
			return entry.ReputationIndex > 0;
		}

		/// <summary>
		/// Indicates if the faction has a parent faction.
		/// </summary>
		/// <typeparam name="TStringType">String type.</typeparam>
		/// <param name="entry">The faction entry.</param>
		/// <returns>True if the faction has a parent team/faction.</returns>
		public static bool HasParentFaction<TStringType>([NotNull] this FactionEntry<TStringType> entry)
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			//Default is 0.
			return entry.ParentFactionId > 0;
		}
	}

	//Faction.dbc
	/// <summary>
	/// Table model for Faction.dbc
	/// https://wowdev.wiki/DB/Faction
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(FactionEntry<>))]
	[Table("Faction")]
	public class FactionEntry<TStringType> : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => FactionId;

		[Key]
		[WireMember(1)]
		public int FactionId { get; private set; }

		/// <summary>
		/// Each faction that has gainable rep has a unique number. All factions that you can not gain rep with have -1. Max value 127.
		/// </summary>
		[WireMember(2)]
		public int ReputationIndex { get; private set; }

		/// <summary>
		/// Indicates the rate of reputation gains.
		/// </summary>
		[WireMember(3)]
		public ReputationRate Rate { get; private set; }

		//Sometimes null/0.
		/// <summary>
		/// Recursive. i.e. Undercity lists ID 67, which is Horde
		/// </summary>
		[WireMember(4)]
		public int ParentFactionId { get; private set; }

		[WireMember(5)]
		public float ParentFactionSpillInMod { get; private set; }

		[WireMember(6)]
		public float ParentFactionSpillOutMod { get; private set; }

		[WireMember(7)]
		public int ParentFactionSpillInMaxRank { get; private set; }

		[WireMember(8)]
		public int ParentFactionSpillOutMaxRank { get; private set; }

		[WireMember(9)]
		public LocalizedStringDBC<TStringType> Name { get; private set; }

		[WireMember(10)]
		public LocalizedStringDBC<TStringType> Description { get; private set; }

		public FactionEntry(int factionId, int reputationIndex, [NotNull] ReputationRate rate, int parentFactionId, int parentFactionSpillInMod, int parentFactionSpillOutMod, int parentFactionSpillInMaxRank, int parentFactionSpillOutMaxRank, [NotNull] LocalizedStringDBC<TStringType> name, [NotNull] LocalizedStringDBC<TStringType> description)
		{
			FactionId = factionId;
			ReputationIndex = reputationIndex;
			Rate = rate ?? throw new ArgumentNullException(nameof(rate));
			ParentFactionId = parentFactionId;
			ParentFactionSpillInMod = parentFactionSpillInMod;
			ParentFactionSpillOutMod = parentFactionSpillOutMod;
			ParentFactionSpillInMaxRank = parentFactionSpillInMaxRank;
			ParentFactionSpillOutMaxRank = parentFactionSpillOutMaxRank;
			Name = name ?? throw new ArgumentNullException(nameof(name));
			Description = description ?? throw new ArgumentNullException(nameof(description));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public FactionEntry()
		{
			
		}
	}
}
