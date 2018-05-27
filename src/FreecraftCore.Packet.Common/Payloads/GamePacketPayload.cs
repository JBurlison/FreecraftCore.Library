﻿using System;
using System.Collections.Generic;
using System.Linq;
using FreecraftCore;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[DefaultChild(typeof(UnknownGamePayload))] //if we encounter something not handled we'll be able to produce an unknown payload
	[WireDataContract(WireDataContractAttribute.KeyType.UShort, true)] //enable runtime linking with second arg
	public abstract class GamePacketPayload : IGamePacketPayload
	{
		//We no longer also write the NetworkOpCode here
		//It is in the header.

		/// <inheritdoc />
		public abstract bool isValid { get; }

		protected GamePacketPayload()
		{
				
		}
	}
}