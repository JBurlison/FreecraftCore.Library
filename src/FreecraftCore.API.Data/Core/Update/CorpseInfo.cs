using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class CorpseInfo
	{
		//TODO: What is this?
		[WireMember(1)]
		public PackedGuid TransportGuid { get; internal set; }

		[WireMember(2)]
		public Vector3<float> GoLocation { get; internal set; }

		[WireMember(3)]
		public Vector3<float> TransportOffset { get; internal set; }

		[WireMember(4)]
		public float Orientation { get; internal set; }

		[WireMember(5)]
		public float CorpseOrientation { get; internal set; }

		/// <inheritdoc />
		public CorpseInfo(PackedGuid transportGuid, Vector3<float> goLocation, Vector3<float> transportOffset, float orientation, float corpseOrientation)
		{
			TransportGuid = transportGuid;
			GoLocation = goLocation;
			TransportOffset = transportOffset;
			Orientation = orientation;
			CorpseOrientation = corpseOrientation;
		}

		protected CorpseInfo()
		{
			
		}
	}
}
