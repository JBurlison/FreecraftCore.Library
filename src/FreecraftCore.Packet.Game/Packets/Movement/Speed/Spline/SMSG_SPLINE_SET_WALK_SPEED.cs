﻿using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Packet payload structure for the <see cref="NetworkOperationCode"/> SMSG_SPLINE_SET_WALK_SPEED.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_SPLINE_SET_WALK_SPEED)]
	public sealed class SMSG_SPLINE_SET_WALK_SPEED_Payload : GamePacketPayload
	{
		/// <summary>
		/// Default Serializer Ctor.
		/// </summary>
		internal SMSG_SPLINE_SET_WALK_SPEED_Payload()
		{

		}
	}
}