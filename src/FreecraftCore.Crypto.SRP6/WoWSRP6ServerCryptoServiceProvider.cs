using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
		public static BigInteger N { get; } = BigInteger.Parse(@"894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7", NumberStyles.HexNumber);

		/// <inheritdoc />
		public WoWSRP6ServerCryptoServiceProvider(string passwordVerifierHex)
			: this(ConvertVerifierToBigInt(passwordVerifierHex))
		{

		}

		private static BigInteger ConvertVerifierToBigInt(string passwordVerifierHex)
		{
			try
			{
				return BigInteger.Parse(passwordVerifierHex, NumberStyles.HexNumber);

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
		public BigInteger GenerateB()
		{
			//Trinitycore
			/*BigNumber gmod = g.ModExp(b, N);
			B = ((v * 3) + gmod) % N;*/
			try
			{
				byte[] bytes = new byte[19];

				randomProvider.GetBytes(bytes);

				BigInteger b = new BigInteger(bytes);
				BigInteger gmod = G.ModPow(b, N);

				return ((V * 3) + gmod) % N;
			}
			catch(Exception e)
			{
				throw new InvalidOperationException($"Error: {e.Message} Failed to generate SRP6 B.", e);
			}
		}

		/// <inheritdoc />
		public void Dispose()
		{
			randomProvider.Dispose();
		}
	}
}
