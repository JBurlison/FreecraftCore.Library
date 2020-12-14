using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	//Different between 1.12.1 and 3.3.5
	//[GamePayloadOperationCode(NetworkOperationCode.SMSG_INIT_WORLD_STATES)]
	//[WireDataContract]
	public sealed class SMSG_INIT_WORLD_STATES_PAYLOAD
	{
		//Trinitycore
		/*
		data << uint32(mapid);                                  // mapid
		data << uint32(zoneid);                                 // zone id
		data << uint32(areaid);                                 // area id, new 2.1.0
		*/

		/// <summary>
		/// The ID of the map to initialize.
		/// </summary>
		[WireMember(1)]
		public int MapId { get; internal set; }

		/// <summary>
		/// The Zone ID of the map to initialize.
		/// </summary>
		[WireMember(2)]
		public int ZoneId { get; internal set; }

		public SMSG_INIT_WORLD_STATES_PAYLOAD()
		{
			
		}
	}
}
