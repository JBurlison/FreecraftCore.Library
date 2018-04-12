using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore
{
	/// <summary>
	/// A generic CRUD interface with generic key/model types.
	/// </summary>
	/// <typeparam name="TKeyType">The type of the key.</typeparam>
	/// <typeparam name="TModelType">The type of the model.</typeparam>
	public interface ICRUDRepository<TKeyType, TModelType>
		where TKeyType : struct
	{
		/// <summary>
		/// CRUD create method that creates a new
		/// model in the repository and returns the entry key.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<TKeyType> Create(TModelType model);

		/// <summary>
		/// CRUD create method that creates a new
		/// model in the repository and with the manually specified key.
		/// </summary>
		/// <param name="key">Manually specified key. (Should be unique)</param>
		/// <param name="model">The model to add as an entry.</param>
		/// <returns></returns>
		Task<bool> TryCreate(TKeyType key, TModelType model);

		/// <summary>
		/// CRUD retrieve that produces t he <see cref="TModelType"/> entry
		/// with the specified key.
		/// Will throw if no key is found.
		/// </summary>
		/// <param name="key"></param>
		/// <exception cref="KeyNotFoundException">Throws if the key is not found.</exception>
		/// <returns>The model associated with thet <see cref="key"/>.</returns>
		Task<TModelType> Retrieve(TKeyType key);

		//TODO: Add update

		//TODO: Add model parameter override
		/// <summary>
		/// CRUD delete that removes an entry with the provided <see cref="key"/>
		/// Will throw if no key is found.
		/// </summary>
		/// <exception cref="KeyNotFoundException">Throws if the key is not found.</exception>
		/// <param name="key">The key of the entry.</param>
		Task Delete(TKeyType key);
	}
}
