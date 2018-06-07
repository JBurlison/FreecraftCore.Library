using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for types that contain player movement information.
	/// </summary>
	/// <typeparam name="TGuidType"></typeparam>
	public interface IPlayerMovementDatable<out TMovementFlagsType>
		where TMovementFlagsType : Enum
	{
		/// <summary>
		/// The movement flags.
		/// </summary>
		TMovementFlagsType MoveFlags { get; }
	}
}
