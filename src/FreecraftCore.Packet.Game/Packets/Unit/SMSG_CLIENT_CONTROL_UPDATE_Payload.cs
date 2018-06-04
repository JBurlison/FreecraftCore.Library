using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Sent by the server when logging in, and in other cases too,
	/// that should enable control of the guid.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_CLIENT_CONTROL_UPDATE)]
	public sealed class SMSG_CLIENT_CONTROL_UPDATE_Payload : GamePacketPayload
	{
		//Both 1.12.1 and 3.3.5 send a packed guid.
		/// <summary>
		/// The object to update control of.
		/// </summary>
		[WireMember(1)]
		public PackedGuid ControlledObject { get; }

		/// <summary>
		/// Indicates if the object is enabled??? TODO: Maybe this means is controlled disbale/enable?
		/// </summary>
		[WireMember(2)]
		public bool IsEnabled { get; }

		/// <inheritdoc />
		public SMSG_CLIENT_CONTROL_UPDATE_Payload([NotNull] PackedGuid controlledObject, bool isEnabled)
		{
			ControlledObject = controlledObject ?? throw new ArgumentNullException(nameof(controlledObject));
			IsEnabled = isEnabled;
		}

		/// <summary>
		/// Serializer
		/// </summary>
		protected SMSG_CLIENT_CONTROL_UPDATE_Payload()
		{
			
		}
	}
}
