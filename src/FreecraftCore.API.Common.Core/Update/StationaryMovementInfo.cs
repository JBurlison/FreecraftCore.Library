using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class StationaryMovementInfo
	{
		[WireMember(1)]
		public Vector3<float> Position { get; }

		[WireMember(2)]
		public float Orientation { get; }

		/// <inheritdoc />
		public StationaryMovementInfo(Vector3<float> position, float orientation)
		{
			Position = position;
			Orientation = orientation;
		}

		protected StationaryMovementInfo()
		{
			
		}
	}
}