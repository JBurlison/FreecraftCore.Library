using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class ParabolicMoveInfo
	{
		/// <summary>
		/// The vertical acceleration of the
		/// parabola.
		/// </summary>
		[WireMember(1)]
		public float VerticalAcceleration { get; }

		/// <summary>
		/// The start time of the parabola.
		/// </summary>
		[WireMember(2)]
		public int StartTime { get; }

		/// <inheritdoc />
		public ParabolicMoveInfo(float verticalAcceleration, int startTime)
		{
			VerticalAcceleration = verticalAcceleration;
			StartTime = startTime;
		}

		public ParabolicMoveInfo()
		{
			
		}
	}
}
