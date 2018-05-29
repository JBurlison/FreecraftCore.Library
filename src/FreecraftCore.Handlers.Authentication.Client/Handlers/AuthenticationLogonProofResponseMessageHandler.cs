using System;
using System.Threading.Tasks;
using GladNet;

namespace FreecraftCore
{
	public class AuthenticationLogonProofResponseMessageHandler : IPeerPayloadSpecificMessageHandler<AuthLogonProofResponse, AuthenticationClientPayload>
	{
		/// <inheritdoc />
		public async Task HandleMessage(IPeerMessageContext<AuthenticationClientPayload> context, AuthLogonProofResponse payload)
		{
			Console.WriteLine($"Proof Result: {payload.AuthResult}");

			//TODO: How should the result be pushed out into UI or other space?
			if(payload.AuthResult == AuthenticationResult.Success)
				await context.PayloadSendService.SendMessage(new AuthRealmListRequest()); //Send the realm list request too.
			else
				await context.ConnectionService.DisconnectAsync(0); //if it's not success when we're done and dead
		}
	}
}
