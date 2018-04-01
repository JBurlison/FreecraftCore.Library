using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Packet.Auth;
using GladNet;
using GladNet3;

namespace Authentication.TestServer
{
	class Program
	{
		static async Task Main(string[] args)
		{
			NetworkAddressInfo info = new NetworkAddressInfo(IPAddress.Parse("127.0.0.1"), 3724);

			AuthenticationServerApplicationBase authServer = new AuthenticationServerApplicationBase(info);

			if(authServer.StartServer())
				await authServer.BeginListening();
			else
			{
				throw new InvalidOperationException($"Unable start server.");
			}
		}
	}
}
