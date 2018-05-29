using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreecraftCore
{
	//TODO: Simplfy throw logic
	/// <summary>
	/// In memory implementation of the <see cref="IAuthenticationAuthChallengeRepository"/>.
	/// </summary>
	public sealed class AuthenticationInMemoryAuthChallengeRepository : IAuthenticationAuthChallengeRepository
	{
		/// <summary>
		/// Thread-safe hash map of entries.
		/// </summary>
		private ConcurrentDictionary<int, AuthenticationChallengeModel> EntryDictionary { get; }

		public AuthenticationInMemoryAuthChallengeRepository()
		{
			EntryDictionary = new ConcurrentDictionary<int, AuthenticationChallengeModel>();
		}

		/// <inheritdoc />
		public Task<bool> HasEntry(int key)
		{
			return Task.FromResult(EntryDictionary.ContainsKey(key));
		}

		/// <inheritdoc />
		public Task<int> Create(AuthenticationChallengeModel model)
		{
			throw new NotSupportedException($"Not supported to add entry to auth challenge repo with no manual key.");
		}

		/// <inheritdoc />
		public async Task<bool> TryCreate(int key, AuthenticationChallengeModel model)
		{
			//TODO: Clean up exception info
			if(await HasEntry(key))
				return false;

			if(!EntryDictionary.TryAdd(key, model))
				return false;

			return true;
		}

		/// <inheritdoc />
		public Task<AuthenticationChallengeModel> Retrieve(int key)
		{
			AuthenticationChallengeModel challenge = null;

			if(!EntryDictionary.TryGetValue(key, out challenge))
				throw new KeyNotFoundException($"Key: {key} not found.");

			return Task.FromResult(challenge);
		}

		/// <inheritdoc />
		public Task Delete(int key)
		{
			AuthenticationChallengeModel challenge = null;

			if(!EntryDictionary.TryRemove(key, out challenge))
				throw new KeyNotFoundException($"Key: {key} not found.");

			return Task.CompletedTask;
		}
	}
}
