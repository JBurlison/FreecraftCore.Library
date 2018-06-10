using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class CreatureQueryResponseInfo_Vanilla
	{
		[Encoding(EncodingType.ASCII)]
		[WireMember(1)]
		[KnownSize(4)]
		public string[] CreatureNames { get; }

		[Encoding(EncodingType.ASCII)]
		[WireMember(2)]
		public string AlternativeName { get; }

		//TODO: Find the enum for this
		[WireMember(4)]
		public CreatureTypeFlags Flags { get; }

		[WireMember(5)]
		public CreatureType CreatureType { get; }

		[WireMember(6)]
		public CreatureFamily Family { get; }

		[WireMember(7)]
		public CreatureEliteType Classification { get; }

		[WireMember(8)]
		public int Unk1 { get; }

		[WireMember(9)]
		public int PetSpellDataId { get; }

		[WireMember(10)]
		public int CreatureDisplayId { get; }

		[WireMember(11)]
		public bool IsCivilian { get; }

		//TODO: What does this mean?
		[WireMember(12)]
		public bool IsLeader { get; }

		/// <inheritdoc />
		public CreatureQueryResponseInfo_Vanilla(string[] creatureNames, string alternativeName, CreatureTypeFlags flags, CreatureType creatureType, CreatureFamily family, CreatureEliteType classification, int unk1, int petSpellDataId, int creatureDisplayId, bool isCivilian, bool isLeader)
		{
			CreatureNames = creatureNames;
			AlternativeName = alternativeName;
			Flags = flags;
			CreatureType = creatureType;
			Family = family;
			Classification = classification;
			Unk1 = unk1;
			PetSpellDataId = petSpellDataId;
			CreatureDisplayId = creatureDisplayId;
			IsCivilian = isCivilian;
			IsLeader = isLeader;
		}

		protected CreatureQueryResponseInfo_Vanilla()
		{
			
		}
	}
}