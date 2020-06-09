using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// The update block involved with object creation.
	/// </summary>
	[WireDataContract]
	public sealed class ObjectUpdateCreateObject1Block_Vanilla : ObjectUpdateBlock_Vanilla
	{
		/// <summary>
		/// The creation data.
		/// </summary>
		[WireMember(1)]
		public ObjectCreationData_Vanilla CreationData { get; internal set; }

		/// <inheritdoc />
		public ObjectUpdateCreateObject1Block_Vanilla(ObjectCreationData_Vanilla creationData)
		{
			CreationData = creationData;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected ObjectUpdateCreateObject1Block_Vanilla()
		{

		}
	}

	/// <summary>
	/// The update block involved with object creation.
	/// </summary>
	[WireDataContract]
	public sealed class ObjectUpdateCreateObject2Block_Vanilla : ObjectUpdateBlock_Vanilla
	{
		/// <summary>
		/// The creation data.
		/// </summary>
		[WireMember(1)]
		public ObjectCreationData_Vanilla CreationData { get; internal set; }

		/// <inheritdoc />
		public ObjectUpdateCreateObject2Block_Vanilla(ObjectCreationData_Vanilla creationData)
			: base()
		{
			CreationData = creationData;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected ObjectUpdateCreateObject2Block_Vanilla()
		{

		}
	}
}
