using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_SPELL_GO)]
	public sealed class SMSG_SPELL_GO_Payload : GamePacketPayload
	{
		[WireMember(1)]
		public SpellCastData CastData { get; internal set; }

		public SMSG_SPELL_GO_Payload([NotNull] SpellCastData castData)
		{
			CastData = castData ?? throw new ArgumentNullException(nameof(castData));
		}

		internal SMSG_SPELL_GO_Payload()
		{
			
		}
	}
}
