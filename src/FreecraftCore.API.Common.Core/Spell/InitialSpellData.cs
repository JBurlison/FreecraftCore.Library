using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class InitialSpellData<TSpellIdType>
		where TSpellIdType : struct
	{
		/// <summary>
		/// The spell id of the data.
		/// </summary>
		[WireMember(1)]
		public TSpellIdType SpellId { get; }

		/// <summary>
		/// UNK data
		/// </summary>
		[WireMember(2)]
		public short UnkShort { get; }

		/// <inheritdoc />
		public InitialSpellData(TSpellIdType spellId, short unkShort)
		{
			SpellId = spellId;
			UnkShort = unkShort;
		}

		protected InitialSpellData()
		{

		}
	}
}
