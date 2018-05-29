using System.Threading.Tasks;

namespace FreecraftCore
{
	/// <summary>
	/// Locking policy that doesn't lock at all.
	/// </summary>
	public sealed class LocklessLockingPolicy : INetworkLockingPolicyStrategy
	{
		/// <inheritdoc />
		public Task LockAsync(NetworkOperationCode operationCode)
		{
			return Task.CompletedTask;
		}

		/// <inheritdoc />
		public void Lock(NetworkOperationCode operationCode)
		{
			//Do nothing, we don't lock with lockless
		}

		/// <inheritdoc />
		public void Unlock(NetworkOperationCode operationCode)
		{
			//Do nothing, we don't lock with lockless
		}

		/// <inheritdoc />
		public void Dispose()
		{

		}

		//Locking policies must be new() able.
		public LocklessLockingPolicy()
		{
			
		}
	}
}
