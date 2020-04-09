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
	//ItemDisplayInfo.dbc
	/// <summary>
	/// Table model for ItemDisplayInfo.dbc
	/// https://wowdev.wiki/DB/ItemDisplayInfo
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[Table("ItemDisplayInfo")]
	public sealed class ItemDisplayInfoEntry : IDBCEntryIdentifiable
	{
		/// <inheritdoc />
		[JsonIgnore]
		public uint EntryId => (uint)ItemDisplayId;

		[Key]
		[WireMember(1)]
		public int ItemDisplayId { get; private set; }

		[WireMember(2)]
		public string LeftModelName { get; private set; }

		[WireMember(3)]
		public string RightModelName { get; private set; }

		[WireMember(4)]
		public string LeftModelTextureName { get; private set; }

		[WireMember(5)]
		public string RightModelTextureName { get; private set; }

		/// <summary>
		/// First icon is actually 
		/// </summary>
		[WireMember(6)]
		public Vector2<string> InventoryIcon { get; private set; }

		//TODO: Don't understand these, probably not going to bother using them for emulation.
		[WireMember(7)]
		public Vector3<int> GeosetGroup { get; private set; }

		/// <summary>
		/// TODO: Unknown flags.
		/// </summary>
		[WireMember(8)]
		public int Flags { get; private set; }

		[WireMember(9)]
		public int SpellVisualId { get; private set; }

		/// <summary>
		/// ItemGroupSounds.dbc
		/// </summary>
		[WireMember(10)]
		public int GroupSoundId { get; private set; }

		/// <summary>
		/// HelmetGeosetVisData.dbc
		/// </summary>
		[WireMember(11)]
		public int HelmentGeosetVisualMale { get; private set; }

		/// <summary>
		/// HelmetGeosetVisData.dbc
		/// </summary>
		[WireMember(12)]
		public int HelmentGeosetVisualFemale { get; private set; }

		[WireMember(13)]
		public string UpperArmTextureName { get; private set; }

		[WireMember(14)]
		public string LowerArmTextureName { get; private set; }

		[WireMember(15)]
		public string HandsTextureName { get; private set; }

		[WireMember(16)]
		public string UpperTorsoTextureName { get; private set; }

		[WireMember(17)]
		public string LowerTorsoTextureName { get; private set; }

		[WireMember(18)]
		public string UpperLegTextureName { get; private set; }

		[WireMember(19)]
		public string LowerLegTextureName { get; private set; }

		[WireMember(20)]
		public string FootTextureName { get; private set; }

		/// <summary>
		/// ItemVisuals.dbc
		/// </summary>
		[WireMember(21)]
		public int ItemVisualId { get; private set; }

		[WireMember(22)]
		public int ParticleColorId { get; private set; }

		public ItemDisplayInfoEntry(int itemDisplayId, [NotNull] string leftModelName, [NotNull] string rightModelName, [NotNull] string leftModelTextureName, [NotNull] string rightModelTextureName, [NotNull] Vector2<string> inventoryIcon, [NotNull] Vector3<int> geosetGroup, int flags, int spellVisualId, int groupSoundId, int helmentGeosetVisualMale, int helmentGeosetVisualFemale, [NotNull] string upperArmTextureName, [NotNull] string lowerArmTextureName, [NotNull] string handsTextureName, [NotNull] string upperTorsoTextureName, [NotNull] string lowerTorsoTextureName, [NotNull] string upperLegTextureName, [NotNull] string lowerLegTextureName, [NotNull] string footTextureName, int itemVisualId, int particleColorId)
		{
			ItemDisplayId = itemDisplayId;
			LeftModelName = leftModelName ?? throw new ArgumentNullException(nameof(leftModelName));
			RightModelName = rightModelName ?? throw new ArgumentNullException(nameof(rightModelName));
			LeftModelTextureName = leftModelTextureName ?? throw new ArgumentNullException(nameof(leftModelTextureName));
			RightModelTextureName = rightModelTextureName ?? throw new ArgumentNullException(nameof(rightModelTextureName));
			InventoryIcon = inventoryIcon ?? throw new ArgumentNullException(nameof(inventoryIcon));
			GeosetGroup = geosetGroup ?? throw new ArgumentNullException(nameof(geosetGroup));
			Flags = flags;
			SpellVisualId = spellVisualId;
			GroupSoundId = groupSoundId;
			HelmentGeosetVisualMale = helmentGeosetVisualMale;
			HelmentGeosetVisualFemale = helmentGeosetVisualFemale;
			UpperArmTextureName = upperArmTextureName ?? throw new ArgumentNullException(nameof(upperArmTextureName));
			LowerArmTextureName = lowerArmTextureName ?? throw new ArgumentNullException(nameof(lowerArmTextureName));
			HandsTextureName = handsTextureName ?? throw new ArgumentNullException(nameof(handsTextureName));
			UpperTorsoTextureName = upperTorsoTextureName ?? throw new ArgumentNullException(nameof(upperTorsoTextureName));
			LowerTorsoTextureName = lowerTorsoTextureName ?? throw new ArgumentNullException(nameof(lowerTorsoTextureName));
			UpperLegTextureName = upperLegTextureName ?? throw new ArgumentNullException(nameof(upperLegTextureName));
			LowerLegTextureName = lowerLegTextureName ?? throw new ArgumentNullException(nameof(lowerLegTextureName));
			FootTextureName = footTextureName ?? throw new ArgumentNullException(nameof(footTextureName));
			ItemVisualId = itemVisualId;
			ParticleColorId = particleColorId;
		}

		/// <summary>
		/// Serializer ctor
		/// </summary>
		public ItemDisplayInfoEntry()
		{
			
		}
	}
}
