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
	//ChrClasses.dbc
	/// <summary>
	/// Table model for ChrClasses.dbc
	/// https://wowdev.wiki/DB/ChrClasses
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(ChrClassesEntry<>))]
	[Table("ChrClasses")]
	public class ChrClassesEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		public static readonly string[] INTERNAL_FIELD_NAMES = new string[] {nameof(Unk1), nameof(RequiredExpansion)};

		[NotMapped] 
		[JsonIgnore] 
		public uint EntryId => (uint) ClassId;

		[Key] 
		[WireMember(1)] 
		public int ClassId { get; private set; }

		[WireMember(2)] 
		internal int Unk1 { get; private set; }

		[WireMember(3)] 
		public SpellCostPower DisplayPower { get; private set; }

		[WireMember(4)] 
		public int PetNameToken { get; private set; }

		[WireMember(5)] 
		public LocalizedStringDBC<TStringType> Name { get; private set; }

		[WireMember(6)] 
		public LocalizedStringDBC<TStringType> FemaleName { get; private set; }

		[WireMember(7)] 
		public LocalizedStringDBC<TStringType> MaleName { get; private set; }

		[WireMember(8)] 
		public TStringType FileName { get; private set; }

		[WireMember(9)] 
		public SpellFamilyName SpellClassSet { get; private set; }

		[WireMember(10)] 
		public CharacterClassEquipmentFlags Flags { get; private set; }

		/// <summary>
		/// Nullable
		/// See: <see cref="CinematicSequencesEntry"/>
		/// Optionally overrides the cinematic sequence in <see cref="ChrRacesEntry{TStringType}"/>
		/// </summary>
		[WireMember(11)]
		public int CinematicSequenceId { get; private set; }

		[WireMember(12)] 
		internal int RequiredExpansion { get; private set; }

		public ChrClassesEntry(int classId, int unk1, SpellCostPower displayPower, int petNameToken, [NotNull] LocalizedStringDBC<TStringType> name, [NotNull] LocalizedStringDBC<TStringType> femaleName, [NotNull] LocalizedStringDBC<TStringType> maleName, [NotNull] TStringType fileName, SpellFamilyName spellClassSet, CharacterClassEquipmentFlags flags, int cinematicSequenceId, int requiredExpansion)
		{
			if (classId <= 0) throw new ArgumentOutOfRangeException(nameof(classId));

			ClassId = classId;
			Unk1 = unk1;
			DisplayPower = displayPower;
			PetNameToken = petNameToken;
			Name = name ?? throw new ArgumentNullException(nameof(name));
			FemaleName = femaleName ?? throw new ArgumentNullException(nameof(femaleName));
			MaleName = maleName ?? throw new ArgumentNullException(nameof(maleName));
			FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
			SpellClassSet = spellClassSet;
			Flags = flags;
			CinematicSequenceId = cinematicSequenceId;
			RequiredExpansion = requiredExpansion;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public ChrClassesEntry()
		{

		}
	}

	public static class ChrClassesEntryExtensions
	{
		public static Expansions GetRequiredExpansion<TStringType>([NotNull] this ChrClassesEntry<TStringType> entry) 
			where TStringType : class
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			return (Expansions) entry.RequiredExpansion;
		}
	}
}
