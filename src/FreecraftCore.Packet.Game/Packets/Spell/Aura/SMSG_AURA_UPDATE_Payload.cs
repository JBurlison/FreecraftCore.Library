﻿using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_AURA_UPDATE)]
	public sealed class SMSG_AURA_UPDATE_Payload
	{
		/// <summary>
		/// The guid of the aura target.
		/// </summary>
		[WireMember(1)]
		public PackedGuid TargetGuid { get; internal set; }

		/// <summary>
		/// The aura update data.
		/// </summary>
		[WireMember(2)]
		public AuraUpdateData Data { get; internal set; }

		public SMSG_AURA_UPDATE_Payload([NotNull] PackedGuid targetGuid, [NotNull] AuraUpdateData data)
		{
			TargetGuid = targetGuid ?? throw new ArgumentNullException(nameof(targetGuid));
			Data = data ?? throw new ArgumentNullException(nameof(data));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		internal SMSG_AURA_UPDATE_Payload()
		{

		}
	}
}
