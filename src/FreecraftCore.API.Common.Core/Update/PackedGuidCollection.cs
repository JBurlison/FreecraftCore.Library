using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class PackedGuidCollection : ReadonlyCollectionContainer<PackedGuid>
	{
		/// <summary>
		/// A collection of packed <see cref="ObjectGuid"/>s
		/// that should be destroyed/have gone out of range.
		/// </summary>
		[SendSize(SendSizeAttribute.SizeType.Int32)]
		[WireMember(1)]
		protected override PackedGuid[] _Items { get; }

		/// <inheritdoc />
		public PackedGuidCollection([NotNull] PackedGuid[] items)
		{
			_Items = items ?? throw new ArgumentNullException(nameof(items));
		}

		protected PackedGuidCollection()
		{

		}
	}
}