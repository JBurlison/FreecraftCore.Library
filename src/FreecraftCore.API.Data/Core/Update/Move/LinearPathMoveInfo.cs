using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	[IncludeCustomTypeSerializer(typeof(LinearPathMoveInfoTypeSerializer))]
	public sealed class LinearPathMoveInfo
	{
		/// <summary>
		/// The final index of the path.
		/// </summary>
		//[WireMember(1)]
		public int LastIndex { get; }

		/// <summary>
		/// The final position of the linear path.
		/// </summary>
		//[WireMember(2)]
		public Vector3<float> FinalPosition { get; }

		//TODO: Actually implement the packed XYZ
		//TODO: Is the same format on 1.12.1? I can't tell.
		public byte[] SplineMiddlePoints { get; }

		/// <inheritdoc />
		public LinearPathMoveInfo(int lastIndex, Vector3<float> finalPosition, byte[] splineMiddlePoints)
		{
			LastIndex = lastIndex;
			FinalPosition = finalPosition;
			SplineMiddlePoints = splineMiddlePoints;
		}

		public LinearPathMoveInfo()
		{
			
		}
	}
}
