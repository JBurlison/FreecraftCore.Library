using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class ObjectCreationData_Vanilla
	{
		/// <summary>
		/// Indicates the <see cref="ObjectGuid"/> type of the creation
		/// update block.
		/// </summary>
		[WireMember(1)]
		public PackedGuid CreationGuid { get; internal set; }

		/// <summary>
		/// The object type of the creation.
		/// </summary>
		[WireMember(2)]
		public ObjectType CreationObjectType { get; internal set; }

		/// <summary>
		/// The movement data.
		/// </summary>
		[WireMember(3)]
		public MovementBlockData_Vanilla MovementData { get; internal set; }

		//Move comes before this
		/// <summary>
		/// The object field values of the created object.
		/// </summary>
		[WireMember(4)]
		public UpdateFieldValueCollection ObjectValuesCollection { get; internal set; }

		/// <inheritdoc />
		public ObjectCreationData_Vanilla(PackedGuid creationGuid, ObjectType creationObjectType, MovementBlockData_Vanilla movementData, UpdateFieldValueCollection objectValuesCollection)
		{
			CreationGuid = creationGuid;
			CreationObjectType = creationObjectType;
			MovementData = movementData;
			ObjectValuesCollection = objectValuesCollection;
		}

		protected ObjectCreationData_Vanilla()
		{

		}
	}
}
