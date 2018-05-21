using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore
{
	//TODO: Should implement flag overloads for query efficiency
	/// <summary>
	/// Contract for <see cref="Realmlist"/> repositories.
	/// </summary>
	public interface IAuthenticationRealmRepository : IDisposable
	{
		/// <summary>
		/// Loads all <see cref="Realmlist"/> (realm) from the
		/// repository.
		/// </summary>
		/// <returns>Collection of all <see cref="Realmlist"/> (realms).</returns>
		Task<IEnumerable<Realmlist>> Retrieve();
	}
}
