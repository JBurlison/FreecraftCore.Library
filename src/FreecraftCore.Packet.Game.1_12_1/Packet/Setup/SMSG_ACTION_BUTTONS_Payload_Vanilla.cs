using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Sent by the server to update the client's
	/// action bindings.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_ACTION_BUTTONS)]
	public sealed class SMSG_ACTION_BUTTONS_Payload_Vanilla : GamePacketPayload
	{
		//#define  MAX_ACTION_BUTTONS 120   // TBC 132 checked in 2.3.0
		[KnownSize(120)] //less than TC
		[WireMember(1)]
		private ActionButtonData[] _ButtonData { get; }

		/// <summary>
		/// The binding/button data collection.
		/// </summary>
		public IReadOnlyCollection<ActionButtonData> ButtonData => _ButtonData;

		//TODO: Validate data
		/// <inheritdoc />
		public SMSG_ACTION_BUTTONS_Payload_Vanilla([NotNull] ActionButtonData[] buttonData)
		{
			_ButtonData = buttonData ?? throw new ArgumentNullException(nameof(buttonData));
		}

		protected SMSG_ACTION_BUTTONS_Payload_Vanilla()
		{

		}
	}
}