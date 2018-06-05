using System;
using System.Collections.Generic;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	//Created only so we can capture the vanilla one and discard it.
	/// <summary>
	/// Sent to the connecting user before the character list.
	/// Sent with <see cref="NetworkOperationCode.SMSG_ADDON_INFO"/>
	/// on 1.12.1 servers.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_ADDON_INFO)]
	public sealed class SMSG_ADDON_INFO_Payload_Vanilla : GamePacketPayload, IUnimplementedGamePacketPayload
	{
		/// <inheritdoc />
		[ReadToEnd]
		[WireMember(1)]
		public byte[] Data { get; set; }

		/// <inheritdoc />
		public SMSG_ADDON_INFO_Payload_Vanilla(byte[] data)
		{
			Data = data;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected SMSG_ADDON_INFO_Payload_Vanilla()
		{

		}
	}
}
