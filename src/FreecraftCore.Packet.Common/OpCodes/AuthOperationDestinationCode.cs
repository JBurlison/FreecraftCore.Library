using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Enumeration of authentication destination codes.
	/// </summary>
	[WireDataContract]
	public enum AuthOperationDestinationCode : byte
	{
		Default = 0,

		/// <summary>
		/// Indicates the destination should be the server.
		/// </summary>
		Server = 1,
		
		Client = 2,
	}
}
