using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	//CreatureDisplayInfoExtra.dbc
	/// <summary>
	/// Table model for CreatureDisplayInfoExtra.dbc
	/// https://wowdev.wiki/DB/CreatureDisplayInfoExtra
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(CreatureDisplayInfoExtraEntry<>))]
	[Table("CreatureDisplayInfoExtra")]
	public class CreatureDisplayInfoExtraEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		public static readonly string[] INTERNAL_FIELD_NAMES = new string[1] { nameof(Sex) };

		[NotMapped]
		[JsonIgnore]
		public uint EntryId => (uint)CreatureDisplayInfoExtraId;

		[Key]
		[WireMember(1)]
		public int CreatureDisplayInfoExtraId { get; private set; }

		/// <summary>
		/// ChrRaces.dbc
		/// TODO: Foreign key reference.
		/// </summary>
		[WireMember(2)]
		public int RaceId { get; private set; }

		[WireMember(3)]
		internal int Sex { get; private set; }

		[NotMapped]
		[JsonIgnore]
		public CharacterGender CreatureSex => (CharacterGender) Sex;

		[WireMember(4)]
		public int SkinId { get; private set; }

		[WireMember(5)]
		public int FaceId { get; private set; }

		/// <summary>
		/// See: CharHairGeosets.dbc
		/// TODO: Implement DBC.
		/// </summary>
		[WireMember(6)]
		public int HairId { get; private set; }

		/// <summary>
		/// See: CharSections.dbc
		/// TODO: Implement DBC.
		/// </summary>
		[WireMember(7)]
		public int HairColorId { get; private set; }

		[WireMember(8)]
		public int FacialHairId { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: ItemDisplayInfo <see cref="ItemDisplayInfoEntry{TStringType}"/>
		/// </summary>
		[WireMember(9)]
		public int HelmItemId { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: ItemDisplayInfo <see cref="ItemDisplayInfoEntry{TStringType}"/>
		/// </summary>
		[WireMember(10)]
		public int ShoulderItemId { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: ItemDisplayInfo <see cref="ItemDisplayInfoEntry{TStringType}"/>
		/// </summary>
		[WireMember(11)]
		public int ShirtItemId { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: ItemDisplayInfo <see cref="ItemDisplayInfoEntry{TStringType}"/>
		/// </summary>
		[WireMember(12)]
		public int CuirassItemId { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: ItemDisplayInfo <see cref="ItemDisplayInfoEntry{TStringType}"/>
		/// </summary>
		[WireMember(13)]
		public int BeltItemId { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: ItemDisplayInfo <see cref="ItemDisplayInfoEntry{TStringType}"/>
		/// </summary>
		[WireMember(14)]
		public int LegsItemId { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: ItemDisplayInfo <see cref="ItemDisplayInfoEntry{TStringType}"/>
		/// </summary>
		[WireMember(15)]
		public int BootsItemId { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: ItemDisplayInfo <see cref="ItemDisplayInfoEntry{TStringType}"/>
		/// </summary>
		[WireMember(16)]
		public int WristItemId { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: ItemDisplayInfo <see cref="ItemDisplayInfoEntry{TStringType}"/>
		/// </summary>
		[WireMember(17)]
		public int GlovesItemId { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: ItemDisplayInfo <see cref="ItemDisplayInfoEntry{TStringType}"/>
		/// </summary>
		[WireMember(18)]
		public int TabardItemId { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: ItemDisplayInfo <see cref="ItemDisplayInfoEntry{TStringType}"/>
		/// </summary>
		[WireMember(19)]
		public int CapeItemId { get; private set; }

		[WireMember(20)]
		public CreatureDisplayInfoExtraFlags Flags { get; private set; }

		[WireMember(21)]
		public TStringType BakedTextureName { get; private set; }

		public CreatureDisplayInfoExtraEntry(int creatureDisplayInfoExtraId, int raceId, int sex, int skinId, int faceId, int hairId, int hairColorId, int facialHairId, int helmItemId, int shoulderItemId, int shirtItemId, int cuirassItemId, int beltItemId, int legsItemId, int bootsItemId, int wristItemId, int glovesItemId, int tabardItemId, int capeItemId, CreatureDisplayInfoExtraFlags flags, [NotNull] TStringType bakedTextureName)
		{
			CreatureDisplayInfoExtraId = creatureDisplayInfoExtraId;
			RaceId = raceId;
			Sex = sex;
			SkinId = skinId;
			FaceId = faceId;
			HairId = hairId;
			HairColorId = hairColorId;
			FacialHairId = facialHairId;
			HelmItemId = helmItemId;
			ShoulderItemId = shoulderItemId;
			ShirtItemId = shirtItemId;
			CuirassItemId = cuirassItemId;
			BeltItemId = beltItemId;
			LegsItemId = legsItemId;
			BootsItemId = bootsItemId;
			WristItemId = wristItemId;
			GlovesItemId = glovesItemId;
			TabardItemId = tabardItemId;
			CapeItemId = capeItemId;
			Flags = flags;
			BakedTextureName = bakedTextureName ?? throw new ArgumentNullException(nameof(bakedTextureName));
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public CreatureDisplayInfoExtraEntry()
		{
			
		}
	}
}
