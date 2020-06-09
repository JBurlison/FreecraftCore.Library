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
		public string[] CreatureNames { get; internal set; }

		[Encoding(EncodingType.ASCII)]
		[WireMember(2)]
		public string AlternativeName { get; internal set; }

		//TODO: Find the enum for this
		[WireMember(4)]
		public CreatureTypeFlags Flags { get; internal set; }

		[WireMember(5)]
		public CreatureType CreatureType { get; internal set; }

		[WireMember(6)]
		public CreatureFamily Family { get; internal set; }

		[WireMember(7)]
		public CreatureEliteType Classification { get; internal set; }

		[WireMember(8)]
		public int Unk1 { get; internal set; }

		[WireMember(9)]
		public int PetSpellDataId { get; internal set; }

		[WireMember(10)]
		public int CreatureDisplayId { get; internal set; }

		[WireMember(11)]
		public bool IsCivilian { get; internal set; }

		//TODO: What does this mean?
		[WireMember(12)]
		public bool IsLeader { get; internal set; }

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
