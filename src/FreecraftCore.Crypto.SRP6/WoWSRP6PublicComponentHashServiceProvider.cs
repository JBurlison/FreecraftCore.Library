﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore.Crypto
{
	/// <summary>
	/// Provides SRP6 public component hashing service.
	/// Review: u on http://srp.stanford.edu/design.html
	/// Or this diagram: https://www.codeproject.com/articles/1082676/communication-using-secure-remote-password-protoco
	/// </summary>
	public class WoWSRP6PublicComponentHashServiceProvider : IDisposable
	{
		[Pure]
		public byte[] Hash(BigInteger componentOne, BigInteger componentTwo)
		{
			return Hash(componentOne.ToCleanByteArray(), componentTwo.ToCleanByteArray());
		}

		[Pure]
		public byte[] Hash([NotNull] byte[] componentOne, [NotNull] byte[] componentTwo)
		{
			if (componentOne == null) throw new ArgumentNullException(nameof(componentOne));
			if (componentTwo == null) throw new ArgumentNullException(nameof(componentTwo));

			//WoW expects non-secure SHA1 hashing. SRP6 is deprecated too. We need to do it anyway
			using (SHA1 shaProvider = SHA1.Create())
			{
				//See Jackpoz's Combine function
				return shaProvider.ComputeHash(componentOne.Concat(componentTwo).ToArray());
			}
		}

		[Pure]
		public byte[] Hash([NotNull] byte[] bytes)
		{
			if (bytes == null) throw new ArgumentNullException(nameof(bytes));

			//WoW expects non-secure SHA1 hashing. SRP6 is deprecated too. We need to do it anyway
			using (SHA1 shaProvider = SHA1.Create())
			{
				return shaProvider.ComputeHash(bytes);
			}
		}

		[Pure]
		public BigInteger HashSessionKey(BigInteger key)
		{
			//See: https://github.com/vermie/MangosClient/blob/master/Client/Authentication/Network/AuthSocket.cs for information
			//This is non-standard SRP6
			//See: https://bnetdocs.org/document/24/nls-srp-protocol
			/*Password Proof (K)
			This value is generated by the client and the server as proof that they actually know the value of S. This is another value which differs from standard SRP, which justs sends SHA1(S).
			Blizzard's version calculates K as follows:
			Place the even bytes of S into one buffer, and the odd bytes into another.
			Create a SHA-1 hash of each buffer.
			Create K by combining the even bytes of the first buffer, and the odd bytes of the second.*/

			byte[] keyHash;
			byte[] sData = key.ToCleanByteArray();
			if (sData.Length != 32)
			{
				var tmpBuffer = new byte[32];
				Buffer.BlockCopy(sData, 0, tmpBuffer, 32 - sData.Length, sData.Length);
				sData = tmpBuffer;
			}

			byte[] keyData = new byte[40];
			byte[] temp = new byte[16];

			// take every even indices byte, hash, store in even indices
			for (int i = 0; i < 16; ++i)
				temp[i] = sData[i * 2];

			using (SHA1 shaProvider = SHA1.Create())
			{
				keyHash = shaProvider.ComputeHash(temp);
			}

			for (int i = 0; i < 20; ++i)
				keyData[i * 2] = keyHash[i];

			// do the same for odd indices
			for (int i = 0; i < 16; ++i)
				temp[i] = sData[i * 2 + 1];

			using (SHA1 shaProvider = SHA1.Create())
			{
				keyHash = shaProvider.ComputeHash(temp);
			}

			for (int i = 0; i < 20; ++i)
				keyData[i * 2 + 1] = keyHash[i];

			return keyData.ToBigInteger();
		}

		/// <summary>
		/// Computes M/M1 for the SRP6 protocol.
		/// M/M1 is defined as H(H(N) xor H(g), H(I), s, A, B, K)
		/// </summary>
		/// <param name="g">Generator.</param>
		/// <param name="N">Modulus</param>
		/// <param name="userName">Unhashed username string.</param>
		/// <param name="salt">Provided challenge salt.</param>
		/// <param name="A">First public component.</param>
		/// <param name="B">Second public component.</param>
		/// <param name="unhashedSessionKey">Unhashed session key (S) which is used to build K = H(S)</param>
		/// <returns>M/M1 byte array.</returns>
		public byte[] ComputeSRP6M1(BigInteger g, BigInteger N, [NotNull] string userName, [NotNull] byte[] salt, BigInteger A, BigInteger B, BigInteger unhashedSessionKey)
		{
			if (salt == null) throw new ArgumentNullException(nameof(salt));
			if (string.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", nameof(userName));

			//Ok, so the client is technically the host in this situation
			//The SRP6 protocol suggests that we provide a proof such as
			//M = H(H(N) xor H(g), H(I), s, A, B, K) to prove we know K, I think.

			//From Mangos client: https://github.com/vermie/MangosClient/blob/master/Client/Authentication/Network/AuthSocket.cs

			byte[] NHash = GenerateHashFor(N);
			byte[] gHash = GenerateHashFor(g);

			//Hash the Username provided
			byte[] hashedUserName = GenerateHashFor(Encoding.ASCII.GetBytes(userName));

			//TODO: Why do we use this hashing algorithm? Is this custom Blizzard hash?
			//Hash session key (K)
			//K = H(S)
			BigInteger hashedSessionKey = HashSessionKey(unhashedSessionKey);

			//XOR the NHash by with the gHash
			for (int i = 0; i < NHash.Length; i++)
				NHash[i] ^= gHash[i];

			//It is not required to clamp the length to 20. All SHA1 hashes are 20 bytes.

			//SRP6 suggests M be the hash of NHash xor'd, hash of identity, salt, public components and hashed session key
			//H(H(N) xor H(g), H(I), s, A, B, H(S))
			return GenerateHashFor(NHash.Concat(hashedUserName)
				.Concat(salt)
				.Concat(A.ToCleanByteArray()) 
				.Concat(B.ToCleanByteArray())
				.Concat(hashedSessionKey.ToCleanByteArray())
				.ToArray());
		}

		[Pure]
		private byte[] GenerateHashFor(BigInteger bigInt)
		{
			return GenerateHashFor(bigInt.ToCleanByteArray());
		}

		[Pure]
		private byte[] GenerateHashFor([NotNull] byte[] bytes)
		{
			if (bytes == null) throw new ArgumentNullException(nameof(bytes));

			using (SHA1 shaProvider = SHA1.Create())
			{
				//Compute SHA1 hash of the provide bigInt
				return shaProvider.ComputeHash(bytes);
			}
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~WoWSRP6PublicComponentHashServiceProvider() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion

	}
}