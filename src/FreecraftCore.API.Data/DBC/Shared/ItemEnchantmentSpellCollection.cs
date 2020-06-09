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
		public GenericStaticallySizedArrayChunkThree<ItemEnchantmentType> Types { get; internal set; }

		[WireMember(2)]
		public GenericStaticallySizedArrayChunkThree<ItemEnchantmentType> PointsMinimum { get; internal set; }

		[WireMember(3)]
		public GenericStaticallySizedArrayChunkThree<ItemEnchantmentType> PointsMaximum { get; internal set; }

		[Column("SpellId")]
		[WireMember(4)]
		public GenericStaticallySizedArrayChunkThree<int> SpellIds { get; internal set; }

		public ItemEnchantmentSpellCollection([NotNull] GenericStaticallySizedArrayChunkThree<ItemEnchantmentType> types, [NotNull] GenericStaticallySizedArrayChunkThree<ItemEnchantmentType> pointsMinimum, [NotNull] GenericStaticallySizedArrayChunkThree<ItemEnchantmentType> pointsMaximum, [NotNull] GenericStaticallySizedArrayChunkThree<int> spellIds)
		{
			Types = types ?? throw new ArgumentNullException(nameof(types));
			PointsMinimum = pointsMinimum ?? throw new ArgumentNullException(nameof(pointsMinimum));
			PointsMaximum = pointsMaximum ?? throw new ArgumentNullException(nameof(pointsMaximum));
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
