using System;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	//AddedInVersion(ClientVersionBuild.V3_1_0_9767) this went from byte to short. so in 1.12.1, if it exists, it will be a byte.
	/// <summary>
	/// Flags enumeration of object updates.
	/// </summary>
	[Flags]
	[WireDataContract]
	public enum ObjectUpdateFlags : ushort //in Jackpoz's bot this is read as a ushort
	{
		UPDATEFLAG_NONE = 0x0000,
		UPDATEFLAG_SELF = 0x0001,
		UPDATEFLAG_TRANSPORT = 0x0002,
		UPDATEFLAG_HAS_TARGET = 0x0004,
		UPDATEFLAG_UNKNOWN = 0x0008,
		UPDATEFLAG_LOWGUID = 0x0010,
		UPDATEFLAG_LIVING = 0x0020,
		UPDATEFLAG_STATIONARY_POSITION = 0x0040,
		UPDATEFLAG_VEHICLE = 0x0080,
		UPDATEFLAG_POSITION = 0x0100,
		UPDATEFLAG_ROTATION = 0x0200
	};
}
