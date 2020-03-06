using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class AnimationInfo
	{
		/// <summary>
		/// The ID of the animation.
		/// </summary>
		[WireMember(1)]
		public byte AnimationId { get; }

		/// <summary>
		/// The start time of the animation.
		/// </summary>
		[WireMember(2)]
		public int StartTime { get; }

		/// <inheritdoc />
		public AnimationInfo(byte animationId, int startTime)
		{
			AnimationId = animationId;
			StartTime = startTime;
		}

		protected AnimationInfo()
		{
			
		}
	}
}
