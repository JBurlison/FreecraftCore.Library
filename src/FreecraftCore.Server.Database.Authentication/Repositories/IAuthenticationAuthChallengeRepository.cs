using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for data service that contains <see cref="AuthenticationChallengeModel"/>s.
	/// </summary>
	public interface IAuthenticationAuthChallengeRepository : ICRUDRepository<int, AuthenticationChallengeModel>
	{
		/// <summary>
		/// Indicates if the authentication challenge entry
		/// with the provided key is present.
		/// </summary>
		/// <param name="key">Key to check for.</param>
		/// <returns>True if the key is present.</returns>
		Task<bool> HasEntry(int key);
	}
}
