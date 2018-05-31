using System;
using System.Collections;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[SeperatedCollectionSize(nameof(ObjectUpdateValuesDiffCollection.UpdatedFields), nameof(ObjectUpdateValuesDiffCollection.ValueUpdateCount))]
	[WireDataContract]
	public sealed class ObjectUpdateValuesDiffCollection
	{
		/// <summary>
		/// Object represents a bitmask that indicates
		/// which fields have updated values sent.
		/// </summary>
		[WireMember(1)]
		public BitArray UpdateMask { get; }

		/// <summary>
		/// The updated object fields.
		/// </summary>
		[WireMember(2)]
		public int[] UpdatedFields { get; }

		/// <inheritdoc />
		public ObjectUpdateValuesDiffCollection(BitArray updateMask, int[] updatedFields)
			: this()
		{
			UpdateMask = updateMask;
			UpdatedFields = updatedFields;
		}

		/// <summary>
		/// Indicates the count of changed/updates fields.
		/// </summary>
		public int ValueUpdateCount => LazyValueUpdateCount.Value;

		/// <summary>
		/// Lazy computed update values.
		/// </summary>
		private Lazy<int> LazyValueUpdateCount { get; }

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public ObjectUpdateValuesDiffCollection()
		{
			LazyValueUpdateCount = new Lazy<int>(() => GetCardinality(this.UpdateMask));
		}

		//See: http://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel
		public static Int32 GetCardinality(BitArray bitArray)
		{
			//TODO: Use a cached array of a fixed size depending on object type
			//TODO: Ensure this is being memcopied.
			Int32[] ints = new Int32[(bitArray.Count >> 5) + 1];
			bitArray.CopyTo(ints, 0);

			Int32 count = 0;

			// fix for not truncated bits in last integer that may have been set to true with SetAll()
			ints[ints.Length - 1] &= ~(-1 << (bitArray.Count % 32));

			for(Int32 i = 0; i < ints.Length; i++)
			{

				Int32 c = ints[i];

				// magic (http://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel)
				unchecked
				{
					c = c - ((c >> 1) & 0x55555555);
					c = (c & 0x33333333) + ((c >> 2) & 0x33333333);
					c = ((c + (c >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
				}

				count += c;

			}

			return count;
		}
	}
}