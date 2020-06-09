using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_SPELL_START)]
	public sealed class SMSG_SPELL_START_Payload : GamePacketPayload
	{
		[WireMember(1)]
		public StartSpellCastData CastData { get; internal set; }

		public SMSG_SPELL_START_Payload([NotNull] StartSpellCastData castData)
		{
			CastData = castData ?? throw new ArgumentNullException(nameof(castData));
		}

		internal SMSG_SPELL_START_Payload()
		{
			
		}
	}
}
