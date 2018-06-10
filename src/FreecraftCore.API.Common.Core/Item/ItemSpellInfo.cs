using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class ItemSpellInfo
	{
		[WireMember(1)]
		public int SpellId { get; }

		[WireMember(2)]
		public int SpellTrigger { get; }

		//TODO: Why does TC set this negative?
		[WireMember(3)]
		public uint SpellCharges { get; }

		[WireMember(4)]
		public uint SpellCooldown { get; }

		[WireMember(5)]
		public uint SpellCategory { get; }

		[WireMember(6)]
		public uint SpellCategoryCooldown { get; }

		/// <inheritdoc />
		public ItemSpellInfo(int spellId, int spellTrigger, uint spellCharges, uint spellCooldown, uint spellCategory, uint spellCategoryCooldown)
		{
			SpellId = spellId;
			SpellTrigger = spellTrigger;
			SpellCharges = spellCharges;
			SpellCooldown = spellCooldown;
			SpellCategory = spellCategory;
			SpellCategoryCooldown = spellCategoryCooldown;
		}

		protected ItemSpellInfo()
		{
			
		}
	}
}
