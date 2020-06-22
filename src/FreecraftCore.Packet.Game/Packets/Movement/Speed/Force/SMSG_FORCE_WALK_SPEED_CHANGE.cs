using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Packet payload structure for the <see cref="NetworkOperationCode"/> SMSG_FORCE_WALK_SPEED_CHANGE.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_FORCE_WALK_SPEED_CHANGE)]
	public sealed class SMSG_FORCE_WALK_SPEED_CHANGE_Payload : GamePacketPayload
	{
		/// <summary>
		/// Default Serializer Ctor.
		/// </summary>
		internal SMSG_FORCE_WALK_SPEED_CHANGE_Payload()
		{

		}
	}
}