using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class ItemDamageDefition
	{
		[WireMember(1)]
		public int DamageMinimum { get; }

		[WireMember(2)]
		public int DamageMaximum { get; }

		//TODO: Find/create enum for this
		[WireMember(3)]
		public int ResistId { get; }

		/// <inheritdoc />
		public ItemDamageDefition(int damageMinimum, int damageMaximum, int resistId)
		{
			DamageMinimum = damageMinimum;
			DamageMaximum = damageMaximum;
			ResistId = resistId;
		}

		protected ItemDamageDefition()
		{
			
		}
	}
}
