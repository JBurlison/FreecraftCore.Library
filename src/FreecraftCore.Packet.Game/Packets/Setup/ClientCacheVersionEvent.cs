using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Sent to the connecting user before the character list.
	/// Sent with <see cref="NetworkOperationCode.SMSG_CLIENTCACHE_VERSION"/>.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_CLIENTCACHE_VERSION)]
	public sealed class ClientCacheVersionEvent : GamePacketPayload
	{
		/// <inheritdoc />
		public override bool isValid => true;

		[ReadToEnd]
		[WireMember(1)]
		public byte[] Data { get; }

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected ClientCacheVersionEvent()
		{
			
		}
	}
}
