using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Crypto;
using NUnit.Framework;

namespace BigInteger.ThirdParty.Tests
{
	[TestFixture]
	public static class BigIntegerToBytesTests
	{
#warning This doesn't check negatives which actually fail
		[Test]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(int.MaxValue)]
		[TestCase(100)]
		[TestCase(5000)]
		public static void Test_SameBytes_As_WCELL(int value)
		{
			//arrange
			WCell.Core.Cryptography.BigInteger WcellBigInt = new WCell.Core.Cryptography.BigInteger(value);
			FreecraftCore.Crypto.BigInteger FreecraftBigInt = new FreecraftCore.Crypto.BigInteger(value);

			AssertBitIntEquivalence(WcellBigInt, FreecraftBigInt);
		}

		private static void AssertBitIntEquivalence(WCell.Core.Cryptography.BigInteger WcellBigInt, FreecraftCore.Crypto.BigInteger FreecraftBigInt)
		{
			//act
			byte[] wcellbytes = WcellBigInt.GetBytes();
			byte[] freecraftbytes = FreecraftBigInt.ToCleanByteArray();

			//assert
			Assert.AreEqual(wcellbytes.Length, freecraftbytes.Length, "BigInteger mismatched length between Wcell and FreecraftCore.");

			for(int i = 0; i < wcellbytes.Length; i++)
				Assert.AreEqual(wcellbytes[i], freecraftbytes[i], $"Byte value mismatch at index: {i} Wcell: {wcellbytes[i]} Freecraft: {freecraftbytes[i]}");
		}

		[Test]
		public static void Test_N_Bytes_Equivalent()
		{
			//arrange
			string N = @"894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7";
			WCell.Core.Cryptography.BigInteger WcellBigInt = new WCell.Core.Cryptography.BigInteger(@"894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7", 16);
			FreecraftCore.Crypto.BigInteger FreecraftBigInt = @"894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7".ToBigInteger();

			AssertBitIntEquivalence(WcellBigInt, FreecraftBigInt);
		}
	}
}
