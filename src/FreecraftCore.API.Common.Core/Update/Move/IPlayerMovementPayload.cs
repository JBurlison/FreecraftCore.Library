using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public interface IPlayerMovementPayload<out TMoveInfoType, TMoveFlagsType>
		where TMoveInfoType : IPlayerMovementDatable<PackedGuid, TMoveFlagsType> 
		where TMoveFlagsType : Enum
	{
		/// <summary>
		/// The movement info.
		/// </summary>
		TMoveInfoType MoveInfo { get; }
	}
}
