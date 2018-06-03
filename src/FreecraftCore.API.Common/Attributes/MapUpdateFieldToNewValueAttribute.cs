using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FreecraftCore
{
	/// <summary>
	/// Metadata marked on update field enums to indicate potential shifts.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class MapUpdateFieldToNewValueAttribute : Attribute
	{
		/// <summary>
		/// Indicates the version this field is being mapped to
		/// from the current version to the target <see cref="ClientVersion"/>.
		/// </summary>
		public ClientBuild ClientVersion { get; }

		/// <summary>
		/// The new value for the target <see cref="ClientVersion"/>.
		/// Meaning the index in the update field collection.
		/// </summary>
		public int NewValue { get; }

		/// <inheritdoc />
		public MapUpdateFieldToNewValueAttribute(ClientBuild clientVersion, int newValue)
		{
			if(!Enum.IsDefined(typeof(ClientBuild), clientVersion)) throw new InvalidEnumArgumentException(nameof(clientVersion), (int)clientVersion, typeof(ClientBuild));

			ClientVersion = clientVersion;
			NewValue = newValue;
		}
	}
}
