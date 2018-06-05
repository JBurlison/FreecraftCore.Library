using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Model that represents the result of an addon
	/// check.
	/// </summary>
	[WireDataContract]
	public sealed class AddonChecksumResult
	{
		/// <summary>
		/// TODO: What does this mean?
		/// </summary>
		[WireMember(1)]
		public byte AddonState { get; } = 2; //TC sends 2 with valid check

		/// <summary>
		/// I think this indicates if the client should do
		/// a CRC check on the addon. If this is set to false it may allow unsigned
		/// Blizzard addons? I don't know.
		/// </summary>
		[WireMember(2)]
		public bool UseCrc { get; }

		[WireMember(3)]
		public bool UsePublicKey { get; }

		[Optional(nameof(UsePublicKey))]
		[KnownSize(256)]
		[WireMember(4)]
		public byte[] PublicKey { get; }

		/// <summary>
		/// Unknown value sent if use CRC is enabled.
		/// </summary>
		[Optional(nameof(UseCrc))]
		[WireMember(5)]
		public int Unk { get; }

		//TODO: What does this mean?
		[WireMember(6)]
		public bool UseUrl { get; }

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected AddonChecksumResult()
		{
			
		}
		
		/// <summary>
		/// Creates a result with a CRC and Public Key enabled at
		/// minimum
		/// </summary>
		/// <param name="publicKey"></param>
		/// <param name="unk"></param>
		/// <param name="useUrl"></param>
		public AddonChecksumResult(byte[] publicKey, int unk, bool useUrl)
		{
			UseCrc = true;
			UsePublicKey = true;
			PublicKey = publicKey;
			Unk = unk;
			UseUrl = useUrl;
		}

		/// <summary>
		/// Creates a result with a Public Key enabled at
		/// minimum.
		/// </summary>
		/// <param name="publicKey"></param>
		/// <param name="useUrl"></param>
		public AddonChecksumResult(byte[] publicKey, bool useUrl)
		{
			UseCrc = false;
			UsePublicKey = true;
			PublicKey = publicKey;
			UseUrl = useUrl;
		}

		/// <inheritdoc />
		public AddonChecksumResult(bool useUrl)
		{
			UseCrc = false;
			UsePublicKey = false;
			UseUrl = useUrl;
		}

		/// <summary>
		/// Creates a result with a CRC enabled.
		/// </summary>
		/// <param name="crcUnkVal"></param>
		/// <param name="useUrl"></param>
		public AddonChecksumResult(int crcUnkVal, bool useUrl)
		{
			UseCrc = true;
			UsePublicKey = false;
			Unk = crcUnkVal;
			UseUrl = useUrl;
		}
	}
}
