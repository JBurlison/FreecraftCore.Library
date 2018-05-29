using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	public sealed class AuthenticationDatabaseRealmRepository : IAuthenticationRealmRepository
	{
		private authContext DatabaseContext { get; }

		/// <inheritdoc />
		public AuthenticationDatabaseRealmRepository([NotNull] authContext databaseContext)
		{
			if(databaseContext == null) throw new ArgumentNullException(nameof(databaseContext));

			DatabaseContext = databaseContext;
		}

		/// <inheritdoc />
		public async Task<IEnumerable<Realmlist>> Retrieve()
		{
			return await DatabaseContext.Realmlist.ToListAsync();
		}

		/// <inheritdoc />
		public void Dispose()
		{
			DatabaseContext.Dispose();
		}
	}
}
