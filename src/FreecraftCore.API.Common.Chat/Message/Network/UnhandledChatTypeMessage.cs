using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public class UnhandledChatTypeMessage : NetworkChatMessage
	{
		protected UnhandledChatTypeMessage()
		{
			
		}
	}
}
