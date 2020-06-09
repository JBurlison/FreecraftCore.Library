using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_INITIAL_SPELLS)]
	public sealed class SMSG_INITIAL_SPELLS_Payload : GamePacketPayload
	{
		/// <summary>
		/// The initial spell data and cooldown data.
		/// Uses int spell ids in 3.3.5.
		/// </summary>
		[WireMember(1)]
		public InitialSpellDataBlock<int> Data { get; internal set; }

		/// <inheritdoc />
		public SMSG_INITIAL_SPELLS_Payload(InitialSpellDataBlock<int> data)
		{
			Data = data;
		}

		protected SMSG_INITIAL_SPELLS_Payload()
		{
			
		}
	}
}
