namespace FreecraftCore
{
	/// <summary>
	/// Represents an unknown game payload.
	/// </summary>
	[ProtocolGrouping(ProtocolCode.None)] //Unknown has no protocol
	public partial class UnknownGamePayload : GamePacketPayload
	{
		public override bool isValid => true;

		public UnknownGamePayload()
			: base(NetworkOperationCode.END)
		{
			//Don't need to initialize anything
			//it's unknown so just check the OpCode to see what it is.
		}
	}
}
