using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for types that contain player movement information.
	/// </summary>
	/// <typeparam name="TGuidType"></typeparam>
	public interface IPlayerMovementDatable<out TGuidType, out TMovementFlagsType>
		where TGuidType : BaseGuid
		where TMovementFlagsType : Enum
	{
		/// <summary>
		/// The GUID associated with the movement.
		/// </summary>
		TGuidType MovementGuid { get; }

		/// <summary>
		/// The movement flags.
		/// </summary>
		TMovementFlagsType MoveFlags { get; }
	}
}
