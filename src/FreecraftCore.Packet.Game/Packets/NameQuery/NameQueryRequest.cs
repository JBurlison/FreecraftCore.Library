using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.CMSG_NAME_QUERY)]
	[ProtocolGrouping(ProtocolCode.Game)] //TODO: Change this protocol to something more specific
	public class NameQueryRequest : GamePacketPayload
	{
		/// <inheritdoc />
		public override bool isValid { get; } = true;

		[WireMember(1)]
		public ObjectGuid TargetGuid { get; private set; }

		public NameQueryRequest([NotNull] ObjectGuid targetGuid)
		{
			if (targetGuid == null)
				throw new ArgumentNullException(nameof(targetGuid));

			TargetGuid = targetGuid;
		}

		protected NameQueryRequest()
		{
			//serializer ctor
		}
	}
}
