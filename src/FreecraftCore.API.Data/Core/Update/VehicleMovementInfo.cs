using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class VehicleMovementInfo
	{
		/// <summary>
		/// 
		/// </summary>
		[WireMember(1)]
		public uint VehicleId { get; }

		[WireMember(2)]
		public float VehicleOrientation { get; }

		/// <inheritdoc />
		public VehicleMovementInfo(uint vehicleId, float vehicleOrientation)
		{
			VehicleId = vehicleId;
			VehicleOrientation = vehicleOrientation;
		}

		protected VehicleMovementInfo()
		{
			
		}
	}
}