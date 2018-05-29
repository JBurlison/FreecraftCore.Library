using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Indicates the <see cref="Client"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public sealed class ForClientBuildAttribute : Attribute
	{
		/// <summary>
		/// Indicates what client build this Type is for.
		/// </summary>
		public ClientBuild BuildNumber { get; }

		/// <inheritdoc />
		public ForClientBuildAttribute(ClientBuild buildNumber)
		{
			if(!Enum.IsDefined(typeof(ClientBuild), buildNumber)) throw new InvalidEnumArgumentException(nameof(buildNumber), (int)buildNumber, typeof(ClientBuild));

			BuildNumber = buildNumber;
		}
	}
}
