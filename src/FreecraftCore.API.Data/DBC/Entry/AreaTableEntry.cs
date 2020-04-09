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
	//AreaTable.dbc
	/// <summary>
	/// Table model for AreaTable.dbc
	/// https://wowdev.wiki/DB/AreaTable
	/// </summary>
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(AreaTableEntry<>))]
	[Table("AreaTable")]
	public class AreaTableEntry<TStringType> : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public uint EntryId => (uint)AreaId;

		[Key]
		[WireMember(1)]
		public int AreaId { get; private set; }

		/// <summary>
		/// The root <see cref="MapEntry{TStringType}"/> id.
		/// </summary>
		[WireMember(2)]
		public int MapId { get; private set; }

		/// <summary>
		/// Map nav property.
		/// </summary>
		[JsonIgnore]
		[ForeignKey(nameof(MapId))]
		public virtual MapEntry<TStringType> Map { get; private set; }

		//TODO: Support nav property. 0 == null in blizzlike.
		[WireMember(4)]
		public int ParentAreaId { get; private set; }

		/// <summary>
		/// Unique and secondary key for <see cref="AreaTableEntry{TStringType}"/> that indicates
		/// the bit to be used in bitmasking/bitwise calculations involving this area.
		/// (Ex. used in Zone exploration).
		/// </summary>
		[WireMember(7)]
		public int AreaBit { get; private set; }

		[WireMember(8)]
		public AreaFlags Flags { get; private set; }

		[WireMember(9)]
		public int SoundProviderPreference { get; private set; }

		[WireMember(10)]
		public int SoundProviderPreferenceUnderwater { get; private set; }

		//TODO: What table is this pointing to?
		[WireMember(11)]
		public int AmbienceId { get; private set; }

		//TODO: What table is this pointing to?
		[WireMember(12)]
		public int ZoneMusicId { get; private set; }

		[WireMember(13)]
		public int IntroSoundId { get; private set; }

		/// <summary>
		/// Negative indicates that area exploration leveling is disabled for this area.
		/// </summary>
		[WireMember(14)]
		public int AreaExplorationLevel { get; private set; }

		[WireMember(15)]
		public LocalizedStringDBC<TStringType> AreaName { get; private set; }

		/// <summary>
		/// See: <see cref="AreaTeams"/>.
		/// </summary>
		[WireMember(16)]
		public AreaTeams FactionTeamMask { get; private set; }

		[WireMember(17)]
		public Vector4<int> LiquidTypeID { get; private set; }

		[WireMember(18)]
		public float MinimumElevation { get; private set; }

		[WireMember(19)]
		public float AmbientMultiplier { get; private set; }

		//TODO: Nav property to light data?
		[WireMember(20)]
		public int LightId { get; private set; }

		public AreaTableEntry(int areaId, int mapId, int parentAreaId, int areaBit, AreaFlags flags, int soundProviderPreference, int soundProviderPreferenceUnderwater, int ambienceId, int zoneMusicId, int introSoundId, int areaExplorationLevel, [NotNull] LocalizedStringDBC<TStringType> areaName, AreaTeams factionTeamMask, [NotNull] Vector4<int> liquidTypeId, float minimumElevation, float ambientMultiplier, int lightId)
		{
			AreaId = areaId;
			MapId = mapId;
			ParentAreaId = parentAreaId;
			AreaBit = areaBit;
			Flags = flags;
			SoundProviderPreference = soundProviderPreference;
			SoundProviderPreferenceUnderwater = soundProviderPreferenceUnderwater;
			AmbienceId = ambienceId;
			ZoneMusicId = zoneMusicId;
			IntroSoundId = introSoundId;
			AreaExplorationLevel = areaExplorationLevel;
			AreaName = areaName ?? throw new ArgumentNullException(nameof(areaName));
			FactionTeamMask = factionTeamMask;
			LiquidTypeID = liquidTypeId ?? throw new ArgumentNullException(nameof(liquidTypeId));
			MinimumElevation = minimumElevation;
			AmbientMultiplier = ambientMultiplier;
			LightId = lightId;
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public AreaTableEntry()
		{
			
		}
	}

	public static class AreaTableEntryExtensions
	{
		public static bool isZone<TStringType>([NotNull] this AreaTableEntry<TStringType> areaEntry)
		{
			if(areaEntry == null) throw new ArgumentNullException(nameof(areaEntry));

			return areaEntry.ParentAreaId == 0;
		}

		//FreecraftCore has its own BigInteger implementation so we must be careful here with namespace.
		//Requires 128bit number.
		public static System.Numerics.BigInteger GetAreaMaskValue<TStringType>([NotNull] this AreaTableEntry<TStringType> areaEntry)
		{
			if(areaEntry == null) throw new ArgumentNullException(nameof(areaEntry));

			return new System.Numerics.BigInteger(1) << areaEntry.AreaBit;
		}

		public static bool RewardsExplorationExperience<TStringType>([NotNull] this AreaTableEntry<TStringType> areaEntry)
		{
			if(areaEntry == null) throw new ArgumentNullException(nameof(areaEntry));

			return areaEntry.AreaExplorationLevel > 0;
		}

		//From TC.
		public static bool IsSanctuary<TStringType>([NotNull] this AreaTableEntry<TStringType> areaEntry)
		{
			if (areaEntry.MapId == 609)
				return true;

			return areaEntry.Flags.HasFlag(AreaFlags.AREA_FLAG_SANCTUARY);
		}

		//From TC.
		public static bool IsFlyable<TStringType>([NotNull] this AreaTableEntry<TStringType> areaEntry)
		{
			if (areaEntry.Flags.HasFlag(AreaFlags.AREA_FLAG_OUTLAND))
			{
				if (!(areaEntry.Flags.HasFlag(AreaFlags.AREA_FLAG_NO_FLY_ZONE)))
					return true;
			}

			return false;
		}
	}
}
