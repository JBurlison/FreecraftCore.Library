using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Shaed Session Authentication data between 1.12.1 and 3.3.5.
	/// It is stored in this sub-DTO because TC sends some additional data at the begining
	/// of the packet that the 1.12.1 version lacks.
	/// </summary>
	[WireDataContract]
	public sealed class SessionAuthChallengeEventData
	{
		//Trinitycore initializes this field as rand32()
		//0 between UINT32 max

		/// <summary>
		/// Random seed sent by the server.
		/// </summary>
		[WireMember(2)]
		public uint AuthenticationSeed { get; internal set; }


		//TODO: Major issue here. 3.3.5 TC sends these seeds. Cmangos sends these seeds. But MANGOS does not. To compensate we send ReadToEnd

		/// <summary>
		/// See documentation about what and why this exists.
		/// Issues with Mangos, Cmangos and Trinitycore compatibility even on Mangos/Cmangos same version.
		/// </summary>
		[ReadToEnd]
		[WireMember(3)]
		public byte[] OptionalSeeds { get; internal set; }

		/*/// <summary>
		/// A 16 byte non-cryptographically secure BigInteger.
		/// It is not stored on Trinitycore or Mangos, isn't sent by EmberEmu
		/// and isn't used by Jazkpoz's bot.
		/// </summary>
		[KnownSize(16)] //jackpoz shows this is a 16 byte BigInt
		[WireMember(3)]
		public byte[] SeedOne { get; internal set; }

		/// <summary>
		/// A 16 byte non-cryptographically secure BigInteger.
		/// It is not stored on Trinitycore or Mangos, isn't sent by EmberEmu
		/// and isn't used by Jazkpoz's bot.
		/// </summary>
		[KnownSize(16)] //jackpoz shows this is a 16 byte BigInt
		[WireMember(4)]
		public byte[] SeedTwo { get; internal set; }*/

		/// <inheritdoc />
		public SessionAuthChallengeEventData(uint authenticationSeed, byte[] optionalSeeds)
		{
			AuthenticationSeed = authenticationSeed;
			OptionalSeeds = optionalSeeds;
		}

		/// <inheritdoc />
		public SessionAuthChallengeEventData(uint authenticationSeed)
			: this(authenticationSeed, Array.Empty<byte>())
		{

		}

		/// <inheritdoc />
		/*public SessionAuthChallengeEventData(uint authenticationSeed, [NotNull] byte[] seedOne, [NotNull] byte[] seedTwo)
		{
			AuthenticationSeed = authenticationSeed;
			SeedOne = seedOne ?? throw new ArgumentNullException(nameof(seedOne));
			SeedTwo = seedTwo ?? throw new ArgumentNullException(nameof(seedTwo));
		}*/



		public SessionAuthChallengeEventData()
		{
			
		}
	}
}
