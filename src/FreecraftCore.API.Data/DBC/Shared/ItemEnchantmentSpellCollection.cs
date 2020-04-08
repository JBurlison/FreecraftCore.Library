using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	[Owned]
	[WireDataContract]
	public sealed class ItemEnchantmentSpellCollection
	{
		[Column("Type")]
		[WireMember(1)]
		public GenericStaticallySizedArrayChunkThree<ItemEnchantmentType> Types { get; private set; }

		[Column("Amount")]
		[WireMember(2)]
		public GenericStaticallySizedArrayChunkThree<ItemEnchantmentType> Amounts { get; private set; }

		[Column("SpellId")]
		[WireMember(3)]
		public GenericStaticallySizedArrayChunkThree<int> SpellIds { get; private set; }

		public ItemEnchantmentSpellCollection([NotNull] GenericStaticallySizedArrayChunkThree<ItemEnchantmentType> types, [NotNull] GenericStaticallySizedArrayChunkThree<ItemEnchantmentType> amounts, [NotNull] GenericStaticallySizedArrayChunkThree<int> spellIds)
		{
			Types = types ?? throw new ArgumentNullException(nameof(types));
			Amounts = amounts ?? throw new ArgumentNullException(nameof(amounts));
			SpellIds = spellIds ?? throw new ArgumentNullException(nameof(spellIds));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public ItemEnchantmentSpellCollection()
		{
			
		}
	}
}
