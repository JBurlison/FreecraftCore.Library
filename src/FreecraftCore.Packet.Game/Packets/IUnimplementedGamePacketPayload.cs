using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public interface IUnimplementedGamePacketPayload
	{
		/// <summary>
		/// The packet data.
		/// </summary>
		[ReadToEnd]
		[WireMember(1)]
		byte[] Data { get; set; }
	}
}
