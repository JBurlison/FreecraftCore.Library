using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class AdjustableSpellMissleInfo
	{
		//TODO: What is this crap?
		[WireMember(1)]
		public float Elevation { get; internal set; }

		[WireMember(2)]
		public uint DelayTimeStamp { get; internal set; }

		public AdjustableSpellMissleInfo(float elevation, uint delayTimeStamp)
		{
			Elevation = elevation;
			DelayTimeStamp = delayTimeStamp;
		}

		public AdjustableSpellMissleInfo()
		{
			
		}
	}
}
