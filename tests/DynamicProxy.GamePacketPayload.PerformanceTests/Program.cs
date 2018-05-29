using System;
using System.Linq;
using FreecraftCore;
using FreecraftCore.Serializer;

namespace DynamicProxy.GamePacketPayload.PerformanceTests
{
	class Program
	{
		static void Main(string[] args)
		{
			SerializerService serializer = new SerializerService();
			Type[] dynamicProxies = GamePacketMetadataMarker.GamePacketPayloadTypesWithDynamicProxies.Value.ToArray();

			foreach(Type t in dynamicProxies)
			{
				//Console.WriteLine($"Registering: {t.Name}");
				//serializer.RegisterType(t);
			}
				

			Console.WriteLine("Finished");
			Console.ReadKey();
		}
	}
}
