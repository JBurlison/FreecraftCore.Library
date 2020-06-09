using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// The vanilla wow version of the update block collection.
	/// </summary>
	[SeperatedCollectionSize(nameof(UpdateBlockCollection_Vanilla._items), nameof(UpdateBlockCollection_Vanilla.UpdateBlockSize))]
	[WireDataContract]
	public sealed class UpdateBlockCollection_Vanilla : ReadonlyCollectionContainer<ObjectUpdateBlock_Vanilla>
	{
		//TODO: Add CTOR for this
		//Pre 3.0.2 they make the dumb mistake of NOT length prefixing this array.
		//So dumb.
		[WireMember(1)]
		public int UpdateBlockSize { get; internal set; }

		//TODO: Add CTOR for this
		//ClientVersion.RemovedInVersion(ClientVersionBuild.V3_0_2_9056) there was a bool inbetween count and array for HasTransport.
		/// <summary>
		/// Indicates if the unit is transporting or something.
		/// Removed in 3.0.2
		/// </summary>
		[WireMember(2)]
		public bool HasTransport { get; internal set; }

		//We do this because the serializer currently chokes
		[SendSize(SendSizeAttribute.SizeType.Int32)]
		[WireMember(3)]
		internal ObjectUpdateBlock_Vanilla[] _items;

		//WPP shows this is sent as a int length prefixed collection of update blocks.
		/// <inheritdoc />
		protected override ObjectUpdateBlock_Vanilla[] _Items => _items;

		public UpdateBlockCollection_Vanilla([NotNull] ObjectUpdateBlock_Vanilla[] items)
		{
			_items = items ?? throw new ArgumentNullException(nameof(items));
		}

		protected UpdateBlockCollection_Vanilla()
		{

		}
	}
}
