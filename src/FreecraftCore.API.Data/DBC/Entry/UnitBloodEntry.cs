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
	//UnitBlood.dbc
	/// <summary>
	/// Table model for UnitBlood.dbc
	/// https://wowdev.wiki/DB/UnitBlood
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(UnitBloodEntry<>))]
	[Table("UnitBlood")]
	public class UnitBloodEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => UnitBloodId;

		[Key]
		[WireMember(1)]
		public int UnitBloodId { get; internal set; }

		[WireMember(2)]
		public int BloodSpurtFrontSmall { get; internal set; }

		[WireMember(3)]
		public int BloodSpurtFrontLarge { get; internal set; }

		[WireMember(4)]
		public int BloodSpurtBackSmall { get; internal set; }

		[WireMember(5)]
		public int BloodSpurtBackLarge { get; internal set; }

		[WireMember(6)]
		public GenericStaticallySizedArrayChunkFive<TStringType> GroundBloodFileName { get; internal set; }

		public UnitBloodEntry(int unitBloodId, int bloodSpurtFrontSmall, int bloodSpurtFrontLarge, int bloodSpurtBackSmall, int bloodSpurtBackLarge, [NotNull] GenericStaticallySizedArrayChunkFive<TStringType> groundBloodFileName)
		{
			if (unitBloodId <= 0) throw new ArgumentOutOfRangeException(nameof(unitBloodId));

			UnitBloodId = unitBloodId;
			BloodSpurtFrontSmall = bloodSpurtFrontSmall;
			BloodSpurtFrontLarge = bloodSpurtFrontLarge;
			BloodSpurtBackSmall = bloodSpurtBackSmall;
			BloodSpurtBackLarge = bloodSpurtBackLarge;
			GroundBloodFileName = groundBloodFileName ?? throw new ArgumentNullException(nameof(groundBloodFileName));
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public UnitBloodEntry()
		{
			
		}
	}

	public static class UnitBloodEntryExtensions
	{
		/// <summary>
		/// Computes the size of <see cref="size"/>
		/// in form of <see cref="Vector2{T}"/> which will contain:
		/// X: Front size
		/// Y: Back size
		/// </summary>
		/// <typeparam name="TStringType"></typeparam>
		/// <param name="entry"></param>
		/// <returns></returns>
		public static Vector2<int> CalculateSize<TStringType>([NotNull] this UnitBloodEntry<TStringType> entry, BloodSpurtSizes size) 
			where TStringType : class
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));
			if (!Enum.IsDefined(typeof(BloodSpurtSizes), size)) throw new InvalidEnumArgumentException(nameof(size), (int) size, typeof(BloodSpurtSizes));

			switch (size)
			{
				case BloodSpurtSizes.SMALL:
					return new Vector2<int>(entry.BloodSpurtFrontSmall, entry.BloodSpurtBackSmall);
				case BloodSpurtSizes.LARGE:
					return new Vector2<int>(entry.BloodSpurtFrontLarge, entry.BloodSpurtBackLarge);
				default:
					throw new ArgumentOutOfRangeException(nameof(size), size, null);
			}
		}
	}
}
