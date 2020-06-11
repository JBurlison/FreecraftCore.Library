using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Builds a path to an asset based on the provided
	/// <see cref="FileName"/>.
	/// </summary>
	public abstract class ContentFilePath
	{
		/// <summary>
		/// The name of the map file.
		/// </summary>
		protected string FileName { get; }

		private Lazy<string> _Path { get; }

		/// <summary>
		/// The path to the map file asset.
		/// </summary>
		public string Path => _Path.Value;

		protected ContentFilePath([NotNull] string fileName)
		{
			if(string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(fileName));

			FileName = fileName;
			_Path = new Lazy<string>(Build, true);
		}

		public static implicit operator string(ContentFilePath path)
		{
			return path?.Path;
		}

		protected abstract string Build();
	}
}
