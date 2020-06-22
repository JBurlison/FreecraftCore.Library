using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Packet payload structure for the <see cref="NetworkOperationCode"/> MSG_MOVE_SET_RUN_SPEED.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.MSG_MOVE_SET_RUN_SPEED)]
	public sealed class MSG_MOVE_SET_RUN_SPEED_Payload : GamePacketPayload
	{
		/// <summary>
		/// Default Serializer Ctor.
		/// </summary>
		internal MSG_MOVE_SET_RUN_SPEED_Payload()
		{

		}
	}
}