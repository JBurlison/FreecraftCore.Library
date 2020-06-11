using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Map file implementation of <see cref="ContentFilePath"/>.
	/// </summary>
	public class MapFilePath : ContentFilePath
	{
		public MapFilePath([NotNull] string fileName)
			: base(fileName)
		{

		}

		protected override string Build()
		{
			return $"World/Maps/{FileName}/{FileName}";
		}
	}
}
