using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_SPELL_FAILURE)]
	public sealed class SMSG_SPELL_FAILURE_Payload : GamePacketPayload
	{
		[WireMember(1)]
		public SpellFailureData FailureData { get; internal set; }

		public SMSG_SPELL_FAILURE_Payload([NotNull] SpellFailureData failureData)
		{
			FailureData = failureData ?? throw new ArgumentNullException(nameof(failureData));
		}

		internal SMSG_SPELL_FAILURE_Payload()
		{
			
		}
	}
}
