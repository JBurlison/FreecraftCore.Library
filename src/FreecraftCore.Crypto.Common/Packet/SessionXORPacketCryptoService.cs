using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FreecraftCore.Crypto;
using JetBrains.Annotations;

namespace FreecraftCore.Crypto
{
	//TODO: Unit test
	/// <summary>
	/// WoW XOR packet "encryption" for older versions of WoW.
	/// Based on Mangos AuthCrypt.cpp.
	/// </summary>
	public class SessionXORPacketCryptoService : ISessionPacketCryptoService
	{
		//Taken from Mangos AuthCrypt.cpp

		/// <summary>
		/// Indicates if this XOR service is for
		/// encryption. If false then it is for decryption.
		/// </summary>
		public bool isForEncrypt { get; }

		//TODO: What is this really?
		private int Index_I;

		//TODO: What is this really?
		private byte Offset_J;

		private byte[] Key { get; }

		/// <inheritdoc />
		public SessionXORPacketCryptoService(bool isForEncrypt, [NotNull] byte[] key)
		{
			this.isForEncrypt = isForEncrypt;
			Key = key ?? throw new ArgumentNullException(nameof(key));
		}

		/// <inheritdoc />
		public void ProcessBytes(byte[] input, int inOff, int length, byte[] output, int outOff)
		{
			if(isForEncrypt)
				Encrypt(input, inOff, length, output, outOff);
			else
				Decrypt(input, inOff, length, output, outOff);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Decrypt(byte[] input, int inOff, int length, byte[] output, int outOff)
		{
			for(int i = inOff; i < (length + inOff); i++)
			{
				Index_I %= Key.Length;
				byte x = (byte)((input[i] - Offset_J) ^ Key[Index_I]);
				++Index_I;
				Offset_J = input[i];
				output[i + outOff] = x;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Encrypt(byte[] input, int inOff, int length, byte[] output, int outOff)
		{
			for(int i = inOff; i < (length + inOff); i++)
			{
				Index_I %= Key.Length;
				byte x = (byte)((input[i] ^ Key[Index_I]) + Offset_J);
				++Index_I;
				output[i + outOff] = Offset_J = x;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private byte Decrypt(byte b)
		{
			Index_I %= Key.Length;
			byte x = (byte)((b - Offset_J) ^ Key[Index_I]);
			++Index_I;
			Offset_J = b;

			return x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private byte Encrypt(byte b)
		{
			Index_I %= Key.Length;
			byte x = (byte)((b ^ Key[Index_I]) + Offset_J);
			++Index_I;
			return Offset_J = x;
		}

		/// <inheritdoc />
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte ReturnByte(byte input)
		{
			if(isForEncrypt)
				return Encrypt(input);
			else
				return Decrypt(input);
		}
	}
}
