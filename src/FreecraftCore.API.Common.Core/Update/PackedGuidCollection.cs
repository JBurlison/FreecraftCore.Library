using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class PackedGuidCollection : ReadonlyCollectionContainer<PackedGuid>
	{
		//We have to do this because serializer will choke otherwise
		[SendSize(SendSizeAttribute.SizeType.Int32)]
		[WireMember(1)]
		private readonly PackedGuid[] _items;

		/// <summary>
		/// A collection of packed <see cref="ObjectGuid"/>s
		/// that should be destroyed/have gone out of range.
		/// </summary>
		protected override PackedGuid[] _Items => _items;

		/// <inheritdoc />
		public PackedGuidCollection([NotNull] PackedGuid[] items)
		{
			_items = items ?? throw new ArgumentNullException(nameof(items));
		}

		protected PackedGuidCollection()
		{

		}
	}
}