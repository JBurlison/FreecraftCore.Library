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
	[WireDataContract]
	public sealed class UpdateBlockCollection_Vanilla : ReadonlyCollectionContainer<ObjectUpdateBlock_Vanilla>
	{
		//ClientVersion.RemovedInVersion(ClientVersionBuild.V3_0_2_9056) there was a bool inbetween count and array for HasTransport.

		//We do this because the serializer currently chokes
		[SendSize(SendSizeAttribute.SizeType.Int32)]
		[WireMember(1)]
		private readonly ObjectUpdateBlock_Vanilla[] _items;

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
