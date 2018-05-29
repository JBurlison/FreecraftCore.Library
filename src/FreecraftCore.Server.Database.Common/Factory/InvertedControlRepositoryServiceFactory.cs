using System;

namespace FreecraftCore
{
	public sealed class InvertedControlRepositoryServiceFactory<TDatabaseServiceType> : IRepositoryServiceFactory<TDatabaseServiceType> 
		where TDatabaseServiceType : IDisposable
	{
		private Func<TDatabaseServiceType> CreationFunc { get; }

		/// <inheritdoc />
		public InvertedControlRepositoryServiceFactory(Func<TDatabaseServiceType> creationFunc)
		{
			if(creationFunc == null) throw new ArgumentNullException(nameof(creationFunc));

			CreationFunc = creationFunc;
		}

		/// <inheritdoc />
		public TDatabaseServiceType Create()
		{
			return CreationFunc();
		}
	}
}
