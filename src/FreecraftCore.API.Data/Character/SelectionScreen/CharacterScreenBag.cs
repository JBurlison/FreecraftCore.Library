using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Represents the bags on the character screen.
	/// Mostly unknown values.
	/// </summary>
	[WireDataContract]
	public class CharacterScreenBag
	{
		//TODO: Figure out what these values are or do
		[WireMember(1)]
		private uint UnknownOne { get; }

		[WireMember(2)]
		private byte UnknownTwo { get; }

		[WireMember(3)]
		private uint UnknownThree { get; }

		/// <inheritdoc />
		public CharacterScreenBag(uint unknownOne, byte unknownTwo, uint unknownThree)
		{
			UnknownOne = unknownOne;
			UnknownTwo = unknownTwo;
			UnknownThree = unknownThree;
		}

		protected CharacterScreenBag()
		{
			//serializer ctor
		}
	}
}
