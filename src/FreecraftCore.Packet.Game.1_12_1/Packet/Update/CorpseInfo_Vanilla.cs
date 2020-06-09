using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class CorpseInfo_Vanilla
	{
		[WireMember(2)]
		public Vector3<float> GoLocation { get; internal set; }

		[WireMember(4)]
		public float Orientation { get; internal set; }

		/// <inheritdoc />
		public CorpseInfo_Vanilla(Vector3<float> goLocation, float orientation)
		{
			GoLocation = goLocation;
			Orientation = orientation;
		}

		protected CorpseInfo_Vanilla()
		{
			
		}
	}
}
