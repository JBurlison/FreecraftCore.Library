using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreecraftCore;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public interface IAuthenticationPacket : INetworkPacket<AuthOperationCode, IAuthenticationPacketHeader, AuthenticationServerPayload>
	{

	}
}
