using FreecraftCore.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreecraftCore.API.Common
{
	[WireDataContract]
	public class RealmBuildInformation
	{
		[WireMember(1)]
		public ExpansionType Expansion { get; }

		[WireMember(2)]
		public byte MajorVersion { get; }

		[WireMember(3)]
		public byte MinorVersion { get; }

		[WireMember(4)]
		public short BuildNumber { get; }

		/// <inheritdoc />
		public RealmBuildInformation(ExpansionType expansion, byte majorVersion, byte minorVersion, short buildNumber)
		{
			if(!Enum.IsDefined(typeof(ExpansionType), expansion)) throw new ArgumentOutOfRangeException(nameof(expansion), "Value should be defined in the ExpansionType enum.");

			Expansion = expansion;
			MajorVersion = majorVersion;
			MinorVersion = minorVersion;
			BuildNumber = buildNumber;
		}

		protected RealmBuildInformation()
		{
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return $"{nameof(Expansion)}: {Expansion} {nameof(MajorVersion)}: {MajorVersion} {nameof(MinorVersion)}: {MinorVersion} {nameof(BuildNumber)}: {BuildNumber}";
		}
	}
}
