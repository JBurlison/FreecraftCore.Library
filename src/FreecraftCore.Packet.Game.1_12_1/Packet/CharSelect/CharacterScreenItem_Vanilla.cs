using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// For 1.12.1 Vanilla packets.
	/// Represents an item worn on the character screen.
	/// Mostly unknown or unhandled values right now.
	/// </summary>
	[WireDataContract]
	public class CharacterScreenItem_Vanilla
	{
		//TODO: Find out what this means

		[WireMember(1)]
		public uint DisplayId { get; }

		//TODO: Find out what this means

		[WireMember(2)]
		public byte InventoryType { get; }

		//1.12.1 doesn't send enchant data
		//[WireMember(3)]
		//private uint EnchantDisplayId { get; }

		public CharacterScreenItem_Vanilla(uint displayId, byte inventoryType)
		{
			DisplayId = displayId;
			InventoryType = inventoryType;
		}

		protected CharacterScreenItem_Vanilla()
		{
			//serializer ctor
		}
	}
}
