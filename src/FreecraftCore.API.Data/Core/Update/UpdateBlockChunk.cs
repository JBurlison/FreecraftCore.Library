namespace FreecraftCore
{
	/// <summary>
	/// Contract for types that are update blocks.
	/// </summary>
	public interface IUpdateBlockChunk
	{
		/// <summary>
		/// Indicates that update type of the chunk.
		/// </summary>
		ObjectUpdateType UpdateType { get; }

		/// <summary>
		/// Indicates the guid of the entity.
		/// </summary>
		ObjectGuid Guid { get; }
	}
}
