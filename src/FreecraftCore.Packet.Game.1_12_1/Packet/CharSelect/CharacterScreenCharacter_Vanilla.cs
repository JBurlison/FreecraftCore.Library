using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public class CharacterScreenCharacter_Vanilla
	{
		/// <summary>
		/// The character data.
		/// </summary>
		[WireMember(1)]
		public CharacterScreenData Data { get; }

		/// <summary>
		/// Indicates if this is the first login by the account.
		/// </summary>
		[WireMember(12)]
		public bool isFirstLogin { get; } //This may be used to tell it to go to character customization?

		/// <summary>
		/// The visual display pet information.
		/// </summary>
		[WireMember(13)]
		public CharacterScreenPetInfo PetInformation { get; }

		//This is slightly different in VanillaWoW
		/// <summary>
		/// Represents the display IDs of the various items equipped by a character so that
		/// the client can render it.
		/// </summary>
		[KnownSize(19)] //Jackpoz has this set as 20 items but reads length - 1 and Trinitycore sends 19 items. SO THERE ARE 19!!
		[WireMember(14)]
		private CharacterScreenItem_Vanilla[] _VisualEquipmentItems { get; }

		/// <summary>
		/// Represents the display IDs of the various items equipped by a character so that
		/// the client can render it.
		/// </summary>
		public IEnumerable<CharacterScreenItem_Vanilla> VisualEquipmentItems => _VisualEquipmentItems;

		//Cmangos shows a 4 byte and 1 byte data at the end of the vanilla packet about bag info
		//p_data << uint32(0);                                   // first bag display id
		//p_data << uint8(0);                                    // first bag inventory type

		[KnownSize(5)]
		[WireMember(15)]
		public byte[] UnknownBagData { get; } = new byte[5];

		/// <inheritdoc />
		public CharacterScreenCharacter_Vanilla([NotNull] CharacterScreenData data, bool isFirstLogin, [NotNull] CharacterScreenPetInfo petInformation, [NotNull] CharacterScreenItem_Vanilla[] visualEquipmentItems)
		{
			Data = data ?? throw new ArgumentNullException(nameof(data));
			this.isFirstLogin = isFirstLogin;
			PetInformation = petInformation ?? throw new ArgumentNullException(nameof(petInformation));
			_VisualEquipmentItems = visualEquipmentItems ?? throw new ArgumentNullException(nameof(visualEquipmentItems));
		}

		protected CharacterScreenCharacter_Vanilla()
		{

		}
	}
}
