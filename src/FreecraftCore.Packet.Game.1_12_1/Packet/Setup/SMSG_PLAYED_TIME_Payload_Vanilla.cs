using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Send by the server in response to a <see cref="NetworkOperationCode.CMSG_PLAYED_TIME"/>
	/// for the 1.12.1 server.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_PLAYED_TIME)]
	public sealed class SMSG_PLAYED_TIME_Payload_Vanilla : GamePacketPayload
	{
		/// <summary>
		/// The total play time for the character.
		/// </summary>
		[WireMember(1)]
		public uint TotalPlayTime { get; }
		
		/// <summary>
		/// The playtime for the character at the current level.
		/// </summary>
		[WireMember(2)]
		public uint PlaytimeAtLevel { get; }

		//1.12.1 version doesn't have the bool.

		/// <inheritdoc />
		public SMSG_PLAYED_TIME_Payload_Vanilla(uint totalPlayTime, uint playtimeAtLevel)
		{
			//TODO: Assert played time
			TotalPlayTime = totalPlayTime;
			PlaytimeAtLevel = playtimeAtLevel;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public SMSG_PLAYED_TIME_Payload_Vanilla()
		{
			
		}
	}
}
