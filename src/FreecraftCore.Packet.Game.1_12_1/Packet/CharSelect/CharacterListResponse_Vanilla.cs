using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore.Packet.CharSelect
{
	/// <summary>
	/// Vanilla 1.12.1 implementation of the <see cref="NetworkOperationCode.SMSG_CHAR_ENUM"/>
	/// packet.
	/// </summary>
	[ForClientBuild(ClientBuild.Vanilla_1_12_1)]
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_CHAR_ENUM)]
	[ProtocolGrouping(ProtocolCode.Game)] //TODO: Change this protocol to something more specific
	public class CharacterListResponse_Vanilla : GamePacketPayload
	{
		/// <inheritdoc />
		public override bool isValid { get; } = true; //TODO: Implement data validation

		[WireMember(1)]
		[SendSize(SendSizeAttribute.SizeType.Byte)] //Jackpoz's bot shows it sends count as byte
		public CharacterScreenCharacter_Vanilla[] Characters { get; internal set; }

		/// <inheritdoc />
		public CharacterListResponse_Vanilla([NotNull] CharacterScreenCharacter_Vanilla[] characters)
		{
			Characters = characters ?? throw new ArgumentNullException(nameof(characters));
		}

		protected CharacterListResponse_Vanilla()
		{
			//serialization ctor
		}
	}
}
