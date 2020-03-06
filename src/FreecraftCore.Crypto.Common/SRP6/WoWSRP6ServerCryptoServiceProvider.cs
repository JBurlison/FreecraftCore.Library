using System;
using System.Security.Cryptography;
using FreecraftCore.Crypto;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class WoWSRP6ServerCryptoServiceProvider : IDisposable
	{
		//TODO: Reimplement secure random generation in netstandard1.6
		//TODO: Implement >net4 Lazy loaded version.
#if !NETSTANDARD1_3 && !NETSTANDARD1_6
		[NotNull]
		private RNGCryptoServiceProvider randomProvider { get; } = new RNGCryptoServiceProvider();
#else
		[NotNull]
		private RandomNumberGenerator randomProvider { get; } = RandomNumberGenerator.Create();
#endif

		/// <summary>
		/// SRP6: V (password verifier)
		/// </summary>
		public BigInteger V { get; }

		public static BigInteger G { get; } = new BigInteger(7);

		//TODO: Generate a new prime
		/// <summary>
		/// N: large prime
		/// </summary>
		public static BigInteger N { get; } = @"894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7".ToBigInteger();

		/// <inheritdoc />
		public WoWSRP6ServerCryptoServiceProvider(string passwordVerifierHex)
			: this(ConvertVerifierToBigInt(passwordVerifierHex))
		{

		}

		private static BigInteger ConvertVerifierToBigInt(string passwordVerifierHex)
		{
			try
			{
				return passwordVerifierHex.ToBigInteger();

			}
			catch(Exception e)
			{
				throw new InvalidOperationException("Failed to convert SRP6 V HexString to BigInteger.", e);
			}
		}

		public WoWSRP6ServerCryptoServiceProvider(BigInteger passwordVerifier)
		{
			V = passwordVerifier;
		}

		/// <summary>
		/// Generates SRP6 B value with the provided V.
		/// </summary>
		/// <returns></returns>
		public BigInteger GeneratePrivateB()
		{
			try
			{
				byte[] bytes = new byte[19];

				randomProvider.GetBytes(bytes);

				//A check from WCELL: https://github.com/WCell/WCell/blob/4f009372d072cff74b7606031673449209ee6e62/Core/WCell.Core/Cryptography/SecureRemotePassword.cs#L452
				// Must make sure the most significant byte is not zero
				if(bytes[0] == 0)
					bytes[0] = 1;

				return bytes.ToBigInteger();
			}
			catch(Exception e)
			{
				throw new InvalidOperationException($"Error: {e.Message} Failed to generate SRP6 B.", e);
			}
		}

		public BigInteger GeneratePublicB(BigInteger secretB)
		{
			//Trinitycore
			/*BigNumber gmod = g.ModExp(b, N);
			B = ((v * 3) + gmod) % N;*/
			BigInteger gmod = G.ModPow(secretB, N);

			BigInteger publicB = ((V * 3) + gmod) % N;

			//A check from WCELL: https://github.com/WCell/WCell/blob/4f009372d072cff74b7606031673449209ee6e62/Core/WCell.Core/Cryptography/SecureRemotePassword.cs#L301
			if(publicB < 0)
			{
				publicB += N;
			}

			return publicB;
		}

		/// <inheritdoc />
		public void Dispose()
		{
			randomProvider.Dispose();
		}
	}
}
