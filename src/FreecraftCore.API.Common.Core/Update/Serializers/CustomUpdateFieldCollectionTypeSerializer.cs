using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// The custom FrecraftCore type serializer for the update field collection
	/// type.
	/// </summary>
	public sealed class CustomUpdateFieldCollectionTypeSerializer : SimpleTypeSerializerStrategy<UpdateFieldValueCollection>
	{
		/// <inheritdoc />
		public override SerializationContextRequirement ContextRequirement { get; } = SerializationContextRequirement.Contextless;

		public CustomUpdateFieldCollectionTypeSerializer()
		{
			
		}

		/// <inheritdoc />
		public override UpdateFieldValueCollection Read(IWireStreamReaderStrategy source)
		{
			//Update fields are sent with an inital byte size
			byte size = source.ReadByte();

			if(size == 0)
				return new UpdateFieldValueCollection(new BitArray(0), Array.Empty<byte>());

			byte[] bytes = source.ReadBytes(size * sizeof(int));

			Console.WriteLine($"UpdateFieldMaskSize: {size}");

			BitArray mask = new BitArray(bytes);

			//We know how many bytes the bitarray is suppose to be
			//but to know how many values are read we need to compute the bit size
			int updateValueSize = GetCardinality(mask);

			Console.WriteLine($"UpdateValueSize: {updateValueSize}");

			AssertSizeIsCorrect(mask, updateValueSize);

			//Once we have the mask AND the bytes we can construct the update values
			byte[] updateValueBytes = source.ReadBytes(updateValueSize * sizeof(int));

			return new UpdateFieldValueCollection(mask, updateValueBytes);
		}

		[Conditional("DEBUG")]
		private static void AssertSizeIsCorrect(BitArray mask, int updateValueSize)
		{
			int count = 0;
			for(int i = 0; i < mask.Length; i++)
				if(mask[i])
					count++;

			if(updateValueSize != count)
				throw new InvalidOperationException($"Failed Standford: {updateValueSize} i: {count}");
		}

		/// <inheritdoc />
		public override void Write(UpdateFieldValueCollection value, IWireStreamWriterStrategy dest)
		{
			//TODO: Major performance gains if we can avoid allocations here. MAJOR!!
			//The size must be equal to the length divided by 8 bits (1 byte) but we do not include the
			//remainder from a modular division. The reason for this is it's always sent as 4 byte chunks from
			//Trinitycore and the size is always in terms of an int array
			byte[] bitmask = new byte[value.UpdateMask.Length / 8];

			((ICollection)value.UpdateMask).CopyTo(bitmask, 0);

			byte size = (byte)(bitmask.Length / sizeof(int));

			//Write the size as if it were an int array first
			dest.Write(size);

			dest.Write(bitmask);

			//We must also write the update values
			dest.Write(value.UpdateDiffValues);
		}

		/// <inheritdoc />
		public override async Task WriteAsync(UpdateFieldValueCollection value, IWireStreamWriterStrategyAsync dest)
		{
			//TODO: Major performance gains if we can avoid allocations here. MAJOR!!
			//The size must be equal to the length divided by 8 bits (1 byte) but we do not include the
			//remainder from a modular division. The reason for this is it's always sent as 4 byte chunks from
			//Trinitycore and the size is always in terms of an int array
			byte[] bitmask = new byte[value.UpdateMask.Count / 8];

			((ICollection)value.UpdateMask).CopyTo(bitmask, 0);

			byte size = (byte)(bitmask.Length / sizeof(int));

			//Write the size as if it were an int array first
			await dest.WriteAsync(size);
			await dest.WriteAsync(bitmask);

			//We must also write the update values
			await dest.WriteAsync(value.UpdateDiffValues);
		}

		/// <inheritdoc />
		public override async Task<UpdateFieldValueCollection> ReadAsync(IWireStreamReaderStrategyAsync source)
		{
			//Update fields are sent with an inital byte size
			byte size = await source.ReadByteAsync();
			byte[] bytes = await source.ReadBytesAsync(size * sizeof(int));

			BitArray mask = new BitArray(bytes);

			//We know how many bytes the bitarray is suppose to be
			//but to know how many values are read we need to compute the bit size
			int updateValueSize = GetCardinality(mask);

			//Once we have the mask AND the bytes we can construct the update values
			byte[] updateValueBytes = await source.ReadBytesAsync(updateValueSize * sizeof(int));

			return new UpdateFieldValueCollection(mask, updateValueBytes);
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
