using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/*
	data << pCurrChar->GetMapId();
	data << pCurrChar->GetPositionX();
	data << pCurrChar->GetPositionY();
	data << pCurrChar->GetPositionZ();
	data << pCurrChar->GetOrientation();
	*/
	
	/// <summary>
	/// Packet sent on initial entry of a character to the world.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_LOGIN_VERIFY_WORLD)]
	public sealed class SMSG_LOGIN_VERIFY_WORLD_PAYLOAD : GamePacketPayload
	{
		/// <summary>
		/// The Map Id to load the character into.
		/// </summary>
		[WireMember(1)]
		public int MapId { get; internal set; }

		/// <summary>
		/// The position of the character.
		/// </summary>
		[WireMember(2)]
		public Vector3<float> Position { get; internal set; }

		/// <summary>
		/// The orientation of the player.
		/// </summary>
		[WireMember(3)]
		public float Orientation { get; internal set; }

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		private SMSG_LOGIN_VERIFY_WORLD_PAYLOAD()
		{
			
		}
	}
}
