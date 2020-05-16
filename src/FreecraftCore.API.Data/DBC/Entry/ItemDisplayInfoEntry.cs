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
	[StringDBC(typeof(ItemDisplayInfoEntry<>))]
	[Table("ItemDisplayInfo")]
	public sealed class ItemDisplayInfoEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		/// <inheritdoc />
		[JsonIgnore]
		[NotMapped]
		public int EntryId => ItemDisplayId;

		[Key]
		[WireMember(1)]
		public int ItemDisplayId { get; private set; }

		[WireMember(2)]
		public TStringType LeftModelName { get; private set; }

		[WireMember(3)]
		public TStringType RightModelName { get; private set; }

		[WireMember(4)]
		public TStringType LeftModelTextureName { get; private set; }

		[WireMember(5)]
		public TStringType RightModelTextureName { get; private set; }

		/// <summary>
		/// First icon is actually 
		/// </summary>
		[WireMember(6)]
		public TStringType InventoryIcon1 { get; private set; }

		[WireMember(7)]
		public TStringType InventoryIcon2 { get; private set; }

		//TODO: Don't understand these, probably not going to bother using them for emulation.
		[WireMember(8)]
		public Vector3<int> GeosetGroup { get; private set; }

		/// <summary>
		/// TODO: Unknown flags.
		/// </summary>
		[WireMember(9)]
		public int Flags { get; private set; }

		[WireMember(10)]
		public int SpellVisualId { get; private set; }

		/// <summary>
		/// ItemGroupSounds.dbc
		/// </summary>
		[WireMember(11)]
		public int GroupSoundId { get; private set; }

		/// <summary>
		/// HelmetGeosetVisData.dbc
		/// </summary>
		[WireMember(12)]
		public int HelmentGeosetVisualMale { get; private set; }

		/// <summary>
		/// HelmetGeosetVisData.dbc
		/// </summary>
		[WireMember(13)]
		public int HelmentGeosetVisualFemale { get; private set; }

		[WireMember(14)]
		public TStringType UpperArmTextureName { get; private set; }

		[WireMember(15)]
		public TStringType LowerArmTextureName { get; private set; }

		[WireMember(16)]
		public TStringType HandsTextureName { get; private set; }

		[WireMember(17)]
		public TStringType UpperTorsoTextureName { get; private set; }

		[WireMember(18)]
		public TStringType LowerTorsoTextureName { get; private set; }

		[WireMember(19)]
		public TStringType UpperLegTextureName { get; private set; }

		[WireMember(20)]
		public TStringType LowerLegTextureName { get; private set; }

		[WireMember(21)]
		public TStringType FootTextureName { get; private set; }

		/// <summary>
		/// ItemVisuals.dbc
		/// </summary>
		[WireMember(22)]
		public int ItemVisualId { get; private set; }

		[WireMember(23)]
		public int ParticleColorId { get; private set; }

		public ItemDisplayInfoEntry(int itemDisplayId, [NotNull] TStringType leftModelName, [NotNull] TStringType rightModelName, [NotNull] TStringType leftModelTextureName, [NotNull] TStringType rightModelTextureName, [NotNull] TStringType inventoryIcon1, [NotNull] TStringType inventoryIcon2, [NotNull] Vector3<int> geosetGroup, int flags, int spellVisualId, int groupSoundId, int helmentGeosetVisualMale, int helmentGeosetVisualFemale, [NotNull] TStringType upperArmTextureName, [NotNull] TStringType lowerArmTextureName, [NotNull] TStringType handsTextureName, [NotNull] TStringType upperTorsoTextureName, [NotNull] TStringType lowerTorsoTextureName, [NotNull] TStringType upperLegTextureName, [NotNull] TStringType lowerLegTextureName, [NotNull] TStringType footTextureName, int itemVisualId, int particleColorId)
		{
			ItemDisplayId = itemDisplayId;
			LeftModelName = leftModelName ?? throw new ArgumentNullException(nameof(leftModelName));
			RightModelName = rightModelName ?? throw new ArgumentNullException(nameof(rightModelName));
			LeftModelTextureName = leftModelTextureName ?? throw new ArgumentNullException(nameof(leftModelTextureName));
			RightModelTextureName = rightModelTextureName ?? throw new ArgumentNullException(nameof(rightModelTextureName));
			InventoryIcon1 = inventoryIcon1 ?? throw new ArgumentNullException(nameof(inventoryIcon1));
			InventoryIcon2 = inventoryIcon2 ?? throw new ArgumentNullException(nameof(inventoryIcon2));
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
