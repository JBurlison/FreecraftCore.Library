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
	//CreatureDisplayInfo.dbc
	/// <summary>
	/// Table model for CreatureDisplayInfo.dbc
	/// https://wowdev.wiki/DB/CreatureDisplayInfo
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(CreatureDisplayInfoEntry<>))]
	[Table("CreatureDisplayInfo")]
	public class CreatureDisplayInfoEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => CreatureDisplayInfoId;

		/// <summary>
		/// 65536 is maximum value on WotLK TC2 for .morph command. For NPCs, higher IDs should be still fine.
		/// </summary>
		[Key]
		[WireMember(1)]
		public int CreatureDisplayInfoId { get; internal set; }

		/// <summary>
		/// A model to be used.
		/// </summary>
		[WireMember(2)]
		public int ModelId { get; internal set; }

		/// <summary>
		/// A model to be used.
		/// </summary>
		[ForeignKey(nameof(ModelId))]
		[JsonIgnore]
		public virtual CreatureModelDataEntry<string> Model { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: <see cref="CreatureSoundDataEntry"/>
		/// If 0 - CreatureModelData information is used.
		/// Otherwise, overrides generic model settings for this displayID.
		/// </summary>
		[WireMember(3)]
		public int SoundIdOverride { get; internal set; }

		/// <summary>
		/// Nullable.
		/// See: <see cref="CreatureDisplayInfoExtraEntry{TStringType}"/>
		/// Applies only to NPCs with character model (hair/facial feature/... and equipment settings).
		/// Not used for creatures.
		/// </summary>
		[WireMember(4)]
		public int ExtraDisplayInformationId { get; internal set; }

		/// <summary>
		/// Default scale. Stacks (by multiplying) with other scale settings (in creature_template, applied auras...).
		/// </summary>
		[WireMember(5)]
		public float CreatureModelScale { get; internal set; }

		/// <summary>
		/// 0 (transparent) to 255 (opaque).
		/// </summary>
		[Range(0, 255)]
		[WireMember(6)]
		public int CreatureModelAlpha { get; internal set; }

		/// <summary>
		/// Name of texture for geoset with type 2.
		/// Texture must be in the same dir as M2 file of creature is.
		/// For: TEX_COMPONENT_OBJECT_SKIN -- Object Skin -- Item, Capes ("Item\ObjectComponents\Cape\*.blp")
		/// One: 1st Geoset
		/// Two: 2nd Geoset
		/// Three: 3rd Geoset
		/// </summary>
		[WireMember(7)]
		public GenericStaticallySizedArrayChunkThree<TStringType> TextureVariation { get; internal set; }

		/// <summary>
		/// Holding an icon like INV_Misc_Food_59. Only on a few.
		/// </summary>
		[WireMember(8)]
		public TStringType PortraitTextureName { get; internal set; }

		/// <summary>
		/// If 0, this is read from CreatureModelData.
		/// (CGUnit::RefreshDataPointers) Seems to have no effect in game.
		/// </summary>
		[WireMember(9)]
		public int BloodLevelIdOverride { get; internal set; }

		/// <summary>
		/// Nullable.
		/// Sets up color of blood.
		/// See: <see cref="UnitBloodEntry{TStringType}"/>
		/// </summary>
		[WireMember(10)]
		public int UnitBloodId { get; internal set; }

		/// <summary>
		/// Nullable.
		/// Sounds used when interacting with the NPC (on-left-click said hello talk).
		/// See: <see cref="NPCSoundsEntry"/>
		/// </summary>
		[WireMember(11)]
		public int NpcSoundsId { get; internal set; }

		/// <summary>
		/// Nullable.
		/// Values are 0 and >281. Wherever they are used.
		/// See: <see cref="ParticleColorEntry"/>
		/// </summary>
		[WireMember(12)]
		public int ParticleId { get; internal set; }

		//TODO: What is this??
		/// <summary>
		/// With this one, you can select a geoset out of the first 8 groups.
		/// 0x00200000 will select geoset 2 out of group 600 and therefore 602.
		/// (Only used by like 10 entries, IronDwarfs.)
		/// See: https://wowdev.wiki/M2/.skin#Mesh_part_ID
		/// </summary>
		[WireMember(13)]
		public int CreatureGeosetData { get; internal set; }

		/// <summary>
		/// Nullable.
		/// Set for gyrocopters, catapults, rocketmounts and siegevehicles. (WotLK).
		/// See: <see cref="ObjectEffectPackageEntry{TStringType}"/>
		/// </summary>
		[WireMember(14)]
		public int ObjectEffectPackageId { get; internal set; }

		public CreatureDisplayInfoEntry(int creatureDisplayInfoId, int modelId, int soundIdOverride, int extraDisplayInformationId, float creatureModelScale, int creatureModelAlpha, [NotNull] GenericStaticallySizedArrayChunkThree<TStringType> textureVariation, [NotNull] TStringType portraitTextureName, int bloodLevelIdOverride, int unitBloodId, int npcSoundsId, int particleId, int creatureGeosetData, int objectEffectPackageId)
		{
			if (creatureDisplayInfoId <= 0) throw new ArgumentOutOfRangeException(nameof(creatureDisplayInfoId));
			if (modelId <= 0) throw new ArgumentOutOfRangeException(nameof(modelId));

			CreatureDisplayInfoId = creatureDisplayInfoId;
			ModelId = modelId;
			SoundIdOverride = soundIdOverride;
			ExtraDisplayInformationId = extraDisplayInformationId;
			CreatureModelScale = creatureModelScale;
			CreatureModelAlpha = creatureModelAlpha;
			TextureVariation = textureVariation ?? throw new ArgumentNullException(nameof(textureVariation));
			PortraitTextureName = portraitTextureName ?? throw new ArgumentNullException(nameof(portraitTextureName));
			BloodLevelIdOverride = bloodLevelIdOverride;
			UnitBloodId = unitBloodId;
			NpcSoundsId = npcSoundsId;
			ParticleId = particleId;
			CreatureGeosetData = creatureGeosetData;
			ObjectEffectPackageId = objectEffectPackageId;
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public CreatureDisplayInfoEntry()
		{
			
		}
	}

	public static class CreatureDisplayInfoExtensions
	{
		public static bool HasOverridenSound<TStringType>([NotNull] this CreatureDisplayInfoEntry<TStringType> entry)
			where TStringType : class
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			return entry.SoundIdOverride > 0;
		}

		public static bool HasOverridenBloodLevel<TStringType>([NotNull] this CreatureDisplayInfoEntry<TStringType> entry)
			where TStringType : class
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			return entry.BloodLevelIdOverride > 0;
		}

		public static int CalculateSoundId<TStringType>([NotNull] this CreatureDisplayInfoEntry<TStringType> entry)
			where TStringType : class
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			if (HasOverridenSound(entry))
				return entry.SoundIdOverride;
			else if (entry.Model != null)
				return entry.Model.SoundDataId;
			else
				throw new InvalidOperationException($"TODO: Support in-memory DBC foreign key relationships.");
		}

		public static int CalculateBloodLevel<TStringType>([NotNull] this CreatureDisplayInfoEntry<TStringType> entry)
			where TStringType : class
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			if (HasOverridenBloodLevel(entry))
				return entry.UnitBloodId;
			else if (entry.Model != null)
				return entry.Model.BloodLevelId;
			else
				throw new InvalidOperationException($"TODO: Support in-memory DBC foreign key relationships.");
		}

		public static IEnumerator<string> EnumerateValidTextureVariations([NotNull] this CreatureDisplayInfoEntry<string> entry)
		{
			foreach(var textureName in entry.TextureVariation)
				if (!string.IsNullOrWhiteSpace(textureName))
					yield return textureName;
		}

		public static bool IsCreatureOpaque<TStringType>([NotNull] this CreatureDisplayInfoEntry<TStringType> entry)
			where TStringType : class
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			return entry.CreatureModelAlpha == byte.MaxValue;
		}

		public static bool IsCreatureTransparent<TStringType>([NotNull] this CreatureDisplayInfoEntry<TStringType> entry)
			where TStringType : class
		{
			if(entry == null) throw new ArgumentNullException(nameof(entry));

			return !IsCreatureOpaque(entry);
		}

		public static bool IsCreatureVisible<TStringType>([NotNull] this CreatureDisplayInfoEntry<TStringType> entry)
			where TStringType : class
		{
			if(entry == null) throw new ArgumentNullException(nameof(entry));

			return entry.CreatureModelAlpha > 0;
		}

		public static bool IsCreatureInvisible<TStringType>([NotNull] this CreatureDisplayInfoEntry<TStringType> entry)
			where TStringType : class
		{
			if(entry == null) throw new ArgumentNullException(nameof(entry));

			return !IsCreatureInvisible<TStringType>(entry);
		}
	}
}
