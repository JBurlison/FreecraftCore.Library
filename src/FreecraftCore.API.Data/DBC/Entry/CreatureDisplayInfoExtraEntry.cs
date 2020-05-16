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
		public int EntryId => CreatureDisplayInfoExtraId;

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

	public static class CreatureDisplayInfoExtraExtensions
	{
		public static bool CanEquipPlayerEquipment<TStringType>([NotNull] this CreatureDisplayInfoExtraEntry<TStringType> entry)
			where TStringType : class
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			return entry.Flags.HasFlag(CreatureDisplayInfoExtraFlags.CanEquipPlayerEquipment);
		}

		public static bool HasEquipment<TStringType>([NotNull] this CreatureDisplayInfoExtraEntry<TStringType> entry, EquipmentSlots slot)
			where TStringType : class
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));
			if (!Enum.IsDefined(typeof(EquipmentSlots), slot)) throw new InvalidEnumArgumentException(nameof(slot), (int) slot, typeof(EquipmentSlots));

			switch (slot)
			{
				case EquipmentSlots.HEAD:
					return entry.HelmItemId > 0;
				case EquipmentSlots.SHOULDERS:
					return entry.ShoulderItemId > 0;
				case EquipmentSlots.BODY:
					return entry.ShirtItemId > 0;
				case EquipmentSlots.CHEST:
					return entry.CuirassItemId > 0;
				case EquipmentSlots.WAIST:
					return entry.BeltItemId > 0;
				case EquipmentSlots.LEGS:
					return entry.LegsItemId > 0;
				case EquipmentSlots.FEET:
					return entry.BootsItemId > 0;
				case EquipmentSlots.WRISTS:
					return entry.WristItemId > 0;
				case EquipmentSlots.HANDS:
					return entry.GlovesItemId > 0;
				case EquipmentSlots.BACK:
					return entry.CapeItemId > 0;
				case EquipmentSlots.TABARD:
					return entry.TabardItemId > 0;

				//These are not on creature display info extra entry.
				case EquipmentSlots.FINGER1:
				case EquipmentSlots.FINGER2:
				case EquipmentSlots.TRINKET1:
				case EquipmentSlots.TRINKET2:
				case EquipmentSlots.MAINHAND:
				case EquipmentSlots.OFFHAND:
				case EquipmentSlots.RANGED:
				case EquipmentSlots.NECK:
					return false;
				default:
					throw new ArgumentOutOfRangeException(nameof(slot), slot, null);
			}
		}

		/// <summary>
		/// Check <see cref="HasEquipment{TStringType}"/> first.
		/// </summary>
		/// <typeparam name="TStringType"></typeparam>
		/// <param name="entry"></param>
		/// <param name="slot"></param>
		/// <returns></returns>
		public static int GetEquipmentId<TStringType>([NotNull] this CreatureDisplayInfoExtraEntry<TStringType> entry, EquipmentSlots slot)
			where TStringType : class
		{
			if(entry == null) throw new ArgumentNullException(nameof(entry));
			if(!Enum.IsDefined(typeof(EquipmentSlots), slot)) throw new InvalidEnumArgumentException(nameof(slot), (int)slot, typeof(EquipmentSlots));

			switch(slot)
			{
				case EquipmentSlots.HEAD:
					return entry.HelmItemId;
				case EquipmentSlots.SHOULDERS:
					return entry.ShoulderItemId;
				case EquipmentSlots.BODY:
					return entry.ShirtItemId;
				case EquipmentSlots.CHEST:
					return entry.CuirassItemId;
				case EquipmentSlots.WAIST:
					return entry.BeltItemId;
				case EquipmentSlots.LEGS:
					return entry.LegsItemId;
				case EquipmentSlots.FEET:
					return entry.BootsItemId;
				case EquipmentSlots.WRISTS:
					return entry.WristItemId;
				case EquipmentSlots.HANDS:
					return entry.GlovesItemId;
				case EquipmentSlots.BACK:
					return entry.CapeItemId;
				case EquipmentSlots.TABARD:
					return entry.TabardItemId;

				//These are not on creature display info extra entry.
				case EquipmentSlots.FINGER1:
				case EquipmentSlots.FINGER2:
				case EquipmentSlots.TRINKET1:
				case EquipmentSlots.TRINKET2:
				case EquipmentSlots.MAINHAND:
				case EquipmentSlots.OFFHAND:
				case EquipmentSlots.RANGED:
				case EquipmentSlots.NECK:
					throw new InvalidOperationException($"Creature does not have Slot: {slot} item id defined. Check {nameof(HasEquipment)} first.");
				default:
					throw new ArgumentOutOfRangeException(nameof(slot), slot, null);
			}
		}
	}
}
