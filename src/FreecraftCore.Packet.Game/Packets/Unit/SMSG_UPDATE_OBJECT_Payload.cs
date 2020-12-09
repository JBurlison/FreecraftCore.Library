using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_UPDATE_OBJECT)]
	public sealed partial class SMSG_UPDATE_OBJECT_Payload : GamePacketPayload, IObjectUpdatePayload
	{
		/// <summary>
		/// The update blocks.
		/// </summary>
		[WireMember(1)]
		public UpdateBlockCollection UpdateBlocks { get; internal set; }

		public SMSG_UPDATE_OBJECT_Payload([NotNull] UpdateBlockCollection updateBlocks)
		{
			UpdateBlocks = updateBlocks ?? throw new ArgumentNullException(nameof(updateBlocks));
		}

		protected SMSG_UPDATE_OBJECT_Payload()
		{
			
		}
	}
}
