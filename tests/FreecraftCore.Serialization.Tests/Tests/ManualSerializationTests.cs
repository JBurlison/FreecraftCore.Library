using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using NUnit.Framework;

namespace FreecraftCore
{
	[TestFixture]
	public class ManualSerializationTests
	{
		[Test]
		public void Test_Can_Serialize_Then_Deserializer_AuthSessionChallengeEvent_Vanilla_Payload()
		{
			//arrange
			SerializerService otherService = new SerializerService();
			otherService.RegisterType<SessionAuthChallengeEvent>();
			
			SerializerService serializer = new SerializerService();
			serializer.RegisterType<SessionAuthChallengeEvent_Vanilla>();
			serializer.Compile();
			otherService.Compile();

			SerializerService lastserializer = new SerializerService();
			lastserializer.RegisterType<SessionAuthChallengeEvent_Vanilla>();
			lastserializer.Compile();

			//act
			byte[] bytes = lastserializer.Serialize(new SessionAuthChallengeEvent_Vanilla(new SessionAuthChallengeEventData(55, new byte[32])));
			SessionAuthChallengeEvent_Vanilla payload = serializer.Deserialize<SessionAuthChallengeEvent_Vanilla>(bytes);

			//assert
			Assert.NotNull(bytes);
		}
	}
}
