namespace FreecraftCore
{
	/// <summary>
	/// Enumeration of all valid Operating Systems types.
	/// </summary>
	public enum OperatingSystemType : byte //uint8 os[4]; (Enum string)
	{
		/// <summary>
		/// Windows operating system.
		/// </summary>
		Win = 1,

		/// <summary>
		/// Unix operating system.
		/// </summary>
		Mac = 2,
	
		/// <summary>
		/// Indicates a mobile client.
		/// </summary>
		Mob = 3
	}
}
