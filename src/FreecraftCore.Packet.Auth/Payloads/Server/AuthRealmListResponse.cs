using FreecraftCore.API.Common;
using FreecraftCore.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace FreecraftCore.Packet.Auth
{
	//TODO: Renable attributes
	/// <summary>
	/// Response payload contains the realm list.
	/// Response to the request <see cref="AuthRealmListRequest"/>.
	/// </summary>
	[WireDataContract]
	[SeperatedCollectionSize(nameof(RealmBytes), nameof(AuthRealmListResponse.RealmListDataSize))]
	[AuthenticationServerPayload(Common.AuthOperationCode.REALM_LIST)] //TODO: Figure out how to support linking with the limited information.
	public class AuthRealmListResponse : AuthenticationServerPayload
	{
		//TODO: Implement
		public override bool isValid { get; } = true;

		//RealmListSizeBuffer << uint32(0); 4 bytes
		//unknown1 (int) + unknown2 (short)
		//6 + size of _Realms
		/// <summary>
		/// The size of the payload.
		/// </summary>
		[WireMember(1)]
		public ushort PayloadSize { get; private set; }

		//Unknown field. Trinitycore always sends 0.
		//I think EmberEmu said it's expected as 0 in the client? Can't recall
		[WireMember(2)]
		private uint unknownOne { get; } = 0;

		internal int RealmListDataSize
		{
			get => PayloadSize - 6;
			set => PayloadSize = (ushort)(value + 6);
		}

		[WireMember(3)]
		public byte[] RealmBytes { get; }

		//TODO: Implement better handling for different client versions
		//2.x and 3.x clients send byte 16 and 0
		//1.12.1 clients send 0 and 2.
		//EmberEmu has no information on what it is.
		[WireMember(4)]
		private short unknownTwo { get; } = 16;

		public AuthRealmListResponse([NotNull] byte[] realmListData)
		{
			if(realmListData == null) throw new ArgumentNullException(nameof(realmListData));

			RealmBytes = realmListData;
			RealmListDataSize = realmListData.Length;
		}

		protected AuthRealmListResponse()
		{

		}
	}
}
