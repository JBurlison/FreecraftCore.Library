using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// The update block involved with object creation.
	/// </summary>
	[WireDataContract]
	public sealed class ObjectUpdateCreateObject1Block : ObjectUpdateBlock
	{
		/// <summary>
		/// The creation data.
		/// </summary>
		[WireMember(1)]
		public ObjectCreationData CreationData { get; }

		/// <inheritdoc />
		public ObjectUpdateCreateObject1Block(ObjectCreationData creationData)
		{
			CreationData = creationData;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected ObjectUpdateCreateObject1Block()
		{
			
		}
	}
}