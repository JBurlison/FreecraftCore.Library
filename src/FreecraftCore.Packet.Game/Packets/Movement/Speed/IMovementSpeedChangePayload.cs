using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for packets that mutate movement speed
	/// of a specified <see cref="ObjectGuid"/>.
	/// </summary>
	public interface IMovementSpeedChangePayload
	{
		/// <summary>
		/// The <see cref="ObjectGuid"/> of the Entity to target for this movement update.
		/// </summary>
		PackedGuid Target { get; }

		/// <summary>
		/// The move type movement speed to mutate.
		/// </summary>
		UnitMoveType MoveType { get; }

		/// <summary>
		/// The new speed to mutate the <see cref="MoveType"/> movement speed by for the <see cref="Target"/>.
		/// </summary>
		float Speed { get; }
	}
}
