using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Crypto;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class AuthenticationChallengeModel
	{
		public string Identity { get; }

		/// <summary>
		/// SRP6: Public random B
		/// </summary>
		public BigInteger PublicB { get; }

		/// <summary>
		/// 
		/// </summary>
		public BigInteger V { get; }

		/// <summary>
		/// SRP6: Private random b (TC)
		/// </summary>
		public BigInteger PrivateB { get; }

		/// <summary>
		/// SRP6: s (salt)
		/// </summary>
		public BigInteger Salt { get; }
		
		//TODO: If we need non-complex EF7/Core we need to add status and key. Status to prevent exploit

		/// <inheritdoc />
		public AuthenticationChallengeModel(BigInteger publicB, BigInteger v, BigInteger privateB, BigInteger salt, [NotNull] string identity)
		{
			if(string.IsNullOrWhiteSpace(identity)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(identity));

			PublicB = publicB;
			V = v;
			PrivateB = privateB;
			Salt = salt;
			Identity = identity;
		}
	}
}
