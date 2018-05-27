using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Common.Logging.Simple;
using FreecraftCore;
using GladNet;

namespace Authentication.TestServer
{
	class Program
	{
		static async Task Main(string[] args)
		{
			NetworkAddressInfo info = new NetworkAddressInfo(IPAddress.Parse("127.0.0.1"), 3724);

			AuthenticationServerApplicationBase authServer = new AuthenticationServerApplicationBase(info, new ConsoleOutLogger("ConsoleLogger", LogLevel.All, true, false, false, null));

			if(authServer.StartServer())
				await authServer.BeginListening()
					.ConfigureAwait(false);
			else
			{
				throw new InvalidOperationException($"Unable start server.");
			}
		}
	}
}
