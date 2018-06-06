using NUnit.Framework;

namespace FreecraftCore.Tests
{
	[TestFixture]
	public class CoreGamePayloadTests : AutomatedReflectionTests<GamePacketPayload, CMSG_NAME_QUERY_Payload>
	{

	}

	[TestFixture]
	public class VanillaGamePayloadTests : AutomatedReflectionTests<GamePacketPayload, SessionAuthProofRequest_Vanilla>
	{

	}

	/*[TestFixture]
	public class WardenPayloadTests : AutomatedReflectionTests<GamePacketPayload, WardenServerPayload>
	{

	}*/
}
