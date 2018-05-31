using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class ObjectCreationData
	{
		/// <summary>
		/// Indicates the <see cref="ObjectGuid"/> type of the creation
		/// update block.
		/// </summary>
		[WireMember(1)]
		public PackedGuid CreationGuid { get; }

		/// <summary>
		/// The object type of the creation.
		/// </summary>
		[WireMember(2)]
		public ObjectType CreationObjectType { get; }

		/// <summary>
		/// The movement data.
		/// </summary>
		[WireMember(3)]
		public MovementBlockData MovementData { get; }

		//Move comes before this
		/// <summary>
		/// The object field values of the created object.
		/// </summary>
		[WireMember(4)]
		public ObjectUpdateValuesDiffCollection ObjectValuesCollection { get; }

		/// <inheritdoc />
		public ObjectCreationData(PackedGuid creationGuid, ObjectType creationObjectType, MovementBlockData movementData, ObjectUpdateValuesDiffCollection objectValuesCollection)
		{
			CreationGuid = creationGuid;
			CreationObjectType = creationObjectType;
			MovementData = movementData;
			ObjectValuesCollection = objectValuesCollection;
		}

		protected ObjectCreationData()
		{
			
		}
	}
}