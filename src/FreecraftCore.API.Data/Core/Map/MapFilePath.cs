using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Builds a path to a map asset based on the provided
	/// <see cref="FileName"/>.
	/// </summary>
	public class MapFilePath
	{
		/// <summary>
		/// The name of the map file.
		/// </summary>
		private string FileName { get; }

		private Lazy<string> _Path { get; }

		/// <summary>
		/// The path to the map file asset.
		/// </summary>
		public string Path { get; }

		public MapFilePath([NotNull] string fileName)
		{
			if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(fileName));

			FileName = fileName;
			_Path = new Lazy<string>(Build, true);
		}

		public static implicit operator string(MapFilePath path)
		{
			if (path == null)
				return null;

			return path.Path;
		}

		protected virtual string Build()
		{
			return $"World/Map/{FileName}";
		}
	}
}
