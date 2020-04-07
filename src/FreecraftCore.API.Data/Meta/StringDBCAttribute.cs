using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Simplified string DBC generic type handling for <see cref="GenericDbcModelAttribute"/>.
	/// </summary>
	public sealed class StringDBCAttribute : GenericDbcModelAttribute
	{
		public StringDBCAttribute([NotNull] Type OpenGenericDBCType) 
			: base(OpenGenericDBCType.MakeGenericType(typeof(StringDBCReference)), OpenGenericDBCType.MakeGenericType(typeof(string)))
		{
			if (OpenGenericDBCType == null) throw new ArgumentNullException(nameof(OpenGenericDBCType));
		}
	}
}
