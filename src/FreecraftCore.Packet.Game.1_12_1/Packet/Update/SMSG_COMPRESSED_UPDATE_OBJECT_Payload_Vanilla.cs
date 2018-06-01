using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// The compressed version of <see cref="NetworkOperationCode.SMSG_UPDATE_OBJECT"/>.
	/// For vanilla 1.12.1.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_COMPRESSED_UPDATE_OBJECT)]
	public sealed class SMSG_COMPRESSED_UPDATE_OBJECT_Payload_Vanilla : GamePacketPayload
	{
		//Compressed update object just uses the regular compression in WoW
		/// <summary>
		/// The update blocks.
		/// </summary>
		[Compress]
		[WireMember(1)]
		public UpdateBlockCollection_Vanilla UpdateBlocks { get; }

		public SMSG_COMPRESSED_UPDATE_OBJECT_Payload_Vanilla([NotNull] UpdateBlockCollection_Vanilla updateBlocks)
		{
			UpdateBlocks = updateBlocks ?? throw new ArgumentNullException(nameof(updateBlocks));
		}

		protected SMSG_COMPRESSED_UPDATE_OBJECT_Payload_Vanilla()
		{

		}
	}

	/// <summary>
	/// The compressed version of <see cref="NetworkOperationCode.SMSG_UPDATE_OBJECT"/>.
	/// For vanilla 1.12.1.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_UPDATE_OBJECT)]
	public sealed class SMSG_UPDATE_OBJECT_Payload_Vanilla : GamePacketPayload
	{
		//Compressed update object just uses the regular compression in WoW
		/// <summary>
		/// The update blocks.
		/// </summary>
		[Compress]
		[WireMember(1)]
		public UpdateBlockCollection_Vanilla UpdateBlocks { get; }

		public SMSG_UPDATE_OBJECT_Payload_Vanilla([NotNull] UpdateBlockCollection_Vanilla updateBlocks)
		{
			UpdateBlocks = updateBlocks ?? throw new ArgumentNullException(nameof(updateBlocks));
		}

		protected SMSG_UPDATE_OBJECT_Payload_Vanilla()
		{

		}
	}
}