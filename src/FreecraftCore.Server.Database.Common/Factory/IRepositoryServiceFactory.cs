using System;

namespace FreecraftCore
{
	/// <summary>
	/// Contract for a factory that generates disposable request-scoped
	/// <see cref="TRepositoryServiceType"/>
	/// </summary>
	/// <typeparam name="TRepositoryServiceType">The data service.</typeparam>
	public interface IRepositoryServiceFactory<out TRepositoryServiceType>
		where TRepositoryServiceType : IDisposable
	{
		TRepositoryServiceType Create();
	}
}
