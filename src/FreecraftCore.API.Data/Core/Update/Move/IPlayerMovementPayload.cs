using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public interface IPlayerMovementPayload<out TMoveInfoType, TMoveFlagsType, out TGUIDType>
		where TMoveInfoType : IPlayerMovementDatable<TMoveFlagsType> 
		where TMoveFlagsType : Enum
		where TGUIDType : BaseGuid
	{

		/// <summary>
		/// The Guid of the movement.
		/// </summary>
		TGUIDType MovementGuid { get; }

		/// <summary>
		/// The movement info.
		/// </summary>
		TMoveInfoType MoveInfo { get; }
	}
}
