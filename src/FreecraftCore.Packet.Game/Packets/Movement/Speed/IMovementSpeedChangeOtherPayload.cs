using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for packet payloads that mutate movement speed like <see cref="IMovementSpeedChangePayload"/>
	/// but contain additional information because it's about remote players.
	/// </summary>
	public interface IMovementSpeedChangeOtherPayload : IMovementSpeedChangePayload
	{
		/// <summary>
		/// The remote <see cref="Target"/>'s <see cref="MovementInfo"/> at the time of the movement speed change.
		/// </summary>
		MovementInfo MovementInformation { get; }
	}
}
