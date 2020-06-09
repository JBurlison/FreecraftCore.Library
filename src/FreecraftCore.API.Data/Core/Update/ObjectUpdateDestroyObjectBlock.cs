using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Block of destroyed object guids.
	/// </summary>
	[WireDataContract]
	public sealed class ObjectUpdateDestroyObjectBlock : ObjectUpdateBlock
	{
		/// <summary>
		/// Collection of object GUIDS that have been destroyed.
		/// </summary>
		[WireMember(1)]
		public PackedGuidCollection DestroyedGuids { get; internal set; }

		/// <inheritdoc />
		public ObjectUpdateDestroyObjectBlock([NotNull] PackedGuidCollection destroyedGuids)
		{
			DestroyedGuids = destroyedGuids ?? throw new ArgumentNullException(nameof(destroyedGuids));
		}

		protected ObjectUpdateDestroyObjectBlock()
		{

		}
	}
}
