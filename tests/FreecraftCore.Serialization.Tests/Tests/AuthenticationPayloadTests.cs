using NUnit.Framework;

namespace FreecraftCore.Tests
{
	[TestFixture]
	public class AuthenticationServerPayloadTests : AutomatedReflectionTests<AuthenticationServerPayload, AuthLogonChallengeResponse>
	{

	}

	[TestFixture]
	public class AuthenticationClientPayloadTests : AutomatedReflectionTests<AuthenticationClientPayload, AuthLogonChallengeRequest>
	{

	}
}
