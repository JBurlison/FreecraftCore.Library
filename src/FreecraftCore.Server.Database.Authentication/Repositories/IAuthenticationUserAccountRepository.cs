using System;
using System.Threading.Tasks;
using FreecraftCore.Crypto;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for an authentication user account repository.
	/// For <see cref="Account"/>s.
	/// </summary>
	public interface IAuthenticationUserAccountRepository : IDisposable
	{
		/// <summary>
		/// Checks if an account is in the database with the provided
		/// <see cref="accountName"/>.
		/// </summary>
		/// <param name="accountName">The account name to check for.</param>
		/// <returns>Indicates if an account is in the database with the provided account name.</returns>
		Task<bool> DoesAccountExists(string accountName);

		/// <summary>
		/// Loads the <see cref="Account"/> model with the specified
		/// <see cref="accountName"/>.
		/// Throws if it does not exist.
		/// </summary>
		/// <param name="accountName">The name of the account.</param>
		/// <returns></returns>
		Task<Account> GetAccount(string accountName);

		/// <summary>
		/// Updates the session key for the account id.
		/// </summary>
		/// <param name="accountId">The account id to update.</param>
		/// <param name="sessionKey">The new session key.</param>
		/// <returns></returns>
		Task UpdateSessionKey(int accountId, BigInteger sessionKey);
	}
}
