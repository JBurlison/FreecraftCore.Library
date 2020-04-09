using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class DbcStringReader : DbcReaderBase, IDbcStringReadable
	{
		/// <summary>
		/// The serializer
		/// </summary>
		private ISerializerService Serializer { get; }

		/// <inheritdoc />
		public DbcStringReader([NotNull] Stream dbcStream, [NotNull] ISerializerService serializer) 
			: base(dbcStream)
		{
			Serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
		}

		/// <inheritdoc />
		public async Task<IReadOnlyDictionary<uint, string>> ParseOnlyStrings()
		{
			return await ReadDBCStringBlock(await this.ReadDBCHeader(Serializer));
		}

		//TODO: Does this work for 0 length blocks?
		private async Task<Dictionary<uint, string>> ReadDBCStringBlock(DBCHeader header)
		{
			Dictionary<uint, string> stringMap = new Dictionary<uint, string>(1000);
			DBCStream.Position = header.StartStringPosition;
			byte[] bytes = new byte[DBCStream.Length - DBCStream.Position];

			await ReadBytesIntoArrayFromStream(bytes);
			DefaultStreamReaderStrategyAsync stringReader = new DefaultStreamReaderStrategyAsync(bytes);

			for(int currentOffset = 0; currentOffset < bytes.Length;)
			{
				string readString = (await Serializer.DeserializeAsync<StringDBC>(stringReader)).StringValue;

				stringMap.Add((uint)currentOffset, readString);

				//We must move the offset forward length + null terminator
				currentOffset += readString.Length + 1;
			}

			return stringMap;
		}
	}
}
