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
	public static class FactionTemplateEntryExtensions
	{
		public const int MAX_FACTION_RELATIONS = 4;

		public static bool IsFriendlyTo(this FactionTemplateEntry entry, FactionTemplateEntry entry2)
		{
			if (entry2.FactionId != 0)
			{
				for (int i = 0; i < MAX_FACTION_RELATIONS; ++i)
					if (entry.EnemyFaction[i] == entry2.FactionId)
						return false;
				for (int i = 0; i < MAX_FACTION_RELATIONS; ++i)
					if (entry.FriendlyFaction[i] == entry2.FactionId)
						return true;
			}

			return ((entry.FriendlyFactionGroupMask & entry2.OwnFactionGroupMask) != 0) || ((entry.OwnFactionGroupMask & entry2.FriendlyFactionGroupMask) != 0);
		}

		public static bool IsHostileTo(this FactionTemplateEntry entry, FactionTemplateEntry entry2)
		{
			if (entry2.FactionId != 0)
			{
				for (int i = 0; i < MAX_FACTION_RELATIONS; ++i)
					if (entry.EnemyFaction[i] == entry2.FactionId)
						return true;

				for (int i = 0; i < MAX_FACTION_RELATIONS; ++i)
					if (entry.FriendlyFaction[i] == entry2.FactionId)
						return false;
			}

			return (entry.EnemyFactionGroupMask & entry2.OwnFactionGroupMask) != 0;
		}

		public static bool IsHostileToPlayers(this FactionTemplateEntry entry)
		{
			return (entry.EnemyFactionGroupMask & FactionGroupMask.PLAYER) != 0;
		}

		public static bool IsNeutralToAll(this FactionTemplateEntry entry)
		{
			for (int i = 0; i < MAX_FACTION_RELATIONS; ++i)
				if (entry.EnemyFaction[i] != 0)
					return false;

			return entry.EnemyFactionGroupMask == 0 && entry.FriendlyFactionGroupMask == 0;
		}

		public static bool IsContestedGuardFaction(this FactionTemplateEntry entry)
		{
			return (entry.FactionFlags & FactionTemplateFlags.FLAG_CONTESTED_GUARD) != 0;
		}
	}

	//FactionTemplate.dbc
	/// <summary>
	/// Table model for FactionTemplate.dbc
	/// https://wowdev.wiki/DB/FactionTemplate
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[Table("FactionTemplate")]
	public class FactionTemplateEntry : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => FactionTemplateId;

		[Key]
		[WireMember(1)]
		public int FactionTemplateId { get; private set; }

		[WireMember(2)]
		public int FactionId { get; private set; }

		/// <summary>
		/// Navigation property linked by <see cref="FactionId"/>.
		/// </summary>
		[ForeignKey(nameof(FactionId))]
		[JsonIgnore]
		public virtual FactionEntry<string> Faction { get; private set; }

		[WireMember(3)]
		public FactionTemplateFlags FactionFlags { get; private set; }

		/// <summary>
		/// If 0 the faction template is not associated with any group.
		/// </summary>
		[WireMember(4)]
		public FactionGroupMask OwnFactionGroupMask { get; private set; }

		/// <summary>
		/// Bitmask of <see cref="FactionGroupMask"/> defined in FactionGroup DBC
		/// that controls friendly groups of factions (if any).
		/// </summary>
		[WireMember(5)]
		public FactionGroupMask FriendlyFactionGroupMask { get; private set; }

		/// <summary>
		/// Bitmask of <see cref="FactionGroupMask"/> defined in FactionGroup DBC
		/// that controls enemy groups of factions (if any).
		/// </summary>
		[WireMember(6)]
		public FactionGroupMask EnemyFactionGroupMask { get; private set; }

		/// <summary>
		/// Explicit additional enemy faction template ids that this template
		/// should be considered enemies with.
		/// These are either 0 or are valid ids of <see cref="FactionEntry{TStringType}"/>.
		/// </summary>
		[WireMember(7)]
		public Vector4<int> EnemyFaction { get; private set; }

		/// <summary>
		/// Explicit additional enemy faction template ids that this template
		/// should be considered enemies with.
		/// These are either 0 or are valid ids of <see cref="FactionEntry{TStringType}"/>.
		/// </summary>
		[WireMember(8)]
		public Vector4<int> FriendlyFaction { get; private set; }

		public FactionTemplateEntry(int factionTemplateId, int factionId, FactionTemplateFlags factionFlags, FactionGroupMask ownFactionGroupMask, FactionGroupMask friendlyFactionGroupMask, FactionGroupMask enemyFactionGroupMask, [NotNull] Vector4<int> enemyFaction, [NotNull] Vector4<int> friendlyFaction)
		{
			FactionTemplateId = factionTemplateId;
			FactionId = factionId;
			FactionFlags = factionFlags;
			OwnFactionGroupMask = ownFactionGroupMask;
			FriendlyFactionGroupMask = friendlyFactionGroupMask;
			EnemyFactionGroupMask = enemyFactionGroupMask;
			EnemyFaction = enemyFaction ?? throw new ArgumentNullException(nameof(enemyFaction));
			FriendlyFaction = friendlyFaction ?? throw new ArgumentNullException(nameof(friendlyFaction));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public FactionTemplateEntry()
		{
			
		}
	}
}
