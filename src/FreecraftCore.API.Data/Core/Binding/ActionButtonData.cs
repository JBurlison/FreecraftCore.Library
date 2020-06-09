using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public class ActionButtonData
	{
		/// <summary>
		/// The packed action data.
		/// </summary>
		[WireMember(1)]
		public uint PackedActionData { get; internal set; }

		/// <summary>
		/// The action button state.
		/// </summary>
		public ActionButtonState ButtonState => (ActionButtonState)(PackedActionData & 0b1111_1111_1111_1111_1111_1111);

		/// <summary>
		/// The action button type.
		/// </summary>
		public ActionButtonType ButtonType => (ActionButtonType)((PackedActionData & ~0b1111_1111_1111_1111_1111_1111) >> 24);

		/// <summary>
		/// Indicates if the data is initialized.
		/// </summary>
		public bool HasData => PackedActionData != 0;

		/// <inheritdoc />
		public ActionButtonData(uint packedActionData)
		{
			PackedActionData = packedActionData;
		}

		public ActionButtonData(ActionButtonState state, ActionButtonType type)
		{
			//From TC: struct ActionButton
			PackedActionData = (uint)state | ((uint)type << 24);
		}

		public ActionButtonData()
		{

		}
	}
}
