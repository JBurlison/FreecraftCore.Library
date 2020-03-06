using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class InitialSpellCooldown<TSpellIdTpye>
		where TSpellIdTpye : struct
	{
		[WireMember(1)]
		public TSpellIdTpye SpellId { get; }

		[WireMember(2)]
		public short ItemId { get; }

		[WireMember(3)]
		public short CategoryId { get; }

		[WireMember(4)]
		public uint SpellCooldown { get; }

		[WireMember(5)]
		public uint CategoryCooldown { get; }

		public bool IsInfiteCooldown => SpellCooldown == 1 && CategoryCooldown == 0x80000000;

		/// <inheritdoc />
		public InitialSpellCooldown(TSpellIdTpye spellId, short itemId, short categoryId, uint spellCooldown, uint categoryCooldown)
		{
			SpellId = spellId;
			ItemId = itemId;
			CategoryId = categoryId;
			SpellCooldown = spellCooldown;
			CategoryCooldown = categoryCooldown;
		}

		protected InitialSpellCooldown()
		{

		}
	}
}
