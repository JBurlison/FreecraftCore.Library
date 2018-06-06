using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_INITIAL_SPELLS)]
	public sealed class SMSG_INITIAL_SPELLS_Payload_Vanilla : GamePacketPayload
	{
		/// <summary>
		/// The initial spell data and cooldown data.
		/// Uses int spell ids in 1.12.1.
		/// </summary>
		[WireMember(1)]
		public InitialSpellDataBlock<ushort> Data { get; }

		/// <inheritdoc />
		public SMSG_INITIAL_SPELLS_Payload_Vanilla(InitialSpellDataBlock<ushort> data)
		{
			Data = data;
		}

		protected SMSG_INITIAL_SPELLS_Payload_Vanilla()
		{

		}
	}
}