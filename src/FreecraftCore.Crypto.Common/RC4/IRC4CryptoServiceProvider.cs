using System;

namespace FreecraftCore.Crypto
{
	/// <summary>
	/// RC4 encryption/decryption service.
	/// </summary>
	public interface IRC4CryptoServiceProvider : ICryptoServiceProvider, IDisposable
	{
		//Temporarily empty
		//Everything was moved to our version of BouncyCastle's ICipherStream.
	}
}
