using FreecraftCore.Serializer;

namespace FreecraftCore
{
	//See: https://github.com/TrinityCore/WowPacketParser/blob/master/WowPacketParser/Parsing/Parsers/UpdateHandler.cs#L2527
	[WireDataContract]
	public sealed class ObjectUpdateMovementBlock_Vanilla : ObjectUpdateBlock_Vanilla
	{
		//ClientVersion.AddedInVersion(ClientVersionBuild.V3_1_2_9901). Pre 3.1 it was a non-packed guid
		[WireMember(1)]
		public ObjectGuid MovementGuid { get; }

		[WireMember(2)]
		public MovementBlockData_Vanilla MovementData { get; }

		/// <inheritdoc />
		public ObjectUpdateMovementBlock_Vanilla(ObjectGuid movementGuid, MovementBlockData_Vanilla movementData)
		{
			MovementGuid = movementGuid;
			MovementData = movementData;
		}

		protected ObjectUpdateMovementBlock_Vanilla()
		{

		}
	}
}