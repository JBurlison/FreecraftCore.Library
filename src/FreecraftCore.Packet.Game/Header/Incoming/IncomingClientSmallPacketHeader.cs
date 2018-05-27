using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FreecraftCore;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	//TODO: Redo this as [ReverseData] BigEndian short for size
	/// <summary>
	/// Small packet header.
	/// </summary>
	public class IncomingClientSmallPacketHeader : IncomingClientPacketHeader
	{
		//[a][b]
		//See: https://github.com/FreecraftCore/FreecraftCore/blob/master/docs/WorldHeader.md
		[KnownSize(2)]
		[WireMember(1)]
		private readonly byte[] encodedSizeBytes; 

		//[cc]
		//See: https://github.com/FreecraftCore/FreecraftCore/blob/master/docs/WorldHeader.md
		/// <inheritdoc />
		[WireMember(2)] //after the 2 bytes of encoded size
		public override NetworkOperationCode OperationCode { get; protected set; }

		//Should be the size of the encoded size in bytes (2) and the OpCode (2)
		/// <inheritdoc />
		public override int HeaderSize { get; } = 2 + sizeof(NetworkOperationCode);

		/// <inheritdoc />
		protected override int ComputePayloadSize()
		{
			if (encodedSizeBytes == null)
				throw new InvalidOperationException($"{nameof(IncomingClientSmallPacketHeader)} did not contain any encoded bytes.");

			//See: https://github.com/FreecraftCore/FreecraftCore/blob/master/docs/WorldHeader.md
			return DecodePayloadSize(encodedSizeBytes);
		}

		/// <summary>
		/// Decodes the 2 byte array for size
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int DecodePayloadSize(byte[] bytes)
		{
			return DecodePacketSize(bytes) - sizeof(NetworkOperationCode);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int DecodePacketSize(byte[] bytes)
		{
			return (int)(((uint)bytes[0]) << 8 | bytes[1]);
		}

		/// <summary>
		/// Decodes the 2 bytes for the size.
		/// The first byte being seperated as it what was decided what packet
		/// type to use.
		/// </summary>
		/// <param name="firstByte"></param>
		/// <param name="followingByte"></param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int DecodePayloadSize(byte firstByte, byte followingByte)
		{
			//We assume correct parameters for performance sake.
			return DecodePacketSize(firstByte, followingByte) - sizeof(NetworkOperationCode);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int DecodePacketSize(byte firstByte, byte followingByte)
		{
			return (int)(((uint)firstByte) << 8 | followingByte);
		}

		//Just check the validity of the encoded size bytes.
		/// <inheritdoc />
		public override bool isValid => encodedSizeBytes != null && encodedSizeBytes.Length == HeaderSize;

		public IncomingClientSmallPacketHeader()
		{
		
		}
	}
}
