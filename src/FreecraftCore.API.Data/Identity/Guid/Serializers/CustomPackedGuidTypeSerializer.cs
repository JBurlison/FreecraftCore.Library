using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// Custom type serializer for <see cref="PackedGuid"/>
	/// </summary>
	public sealed class CustomPackedGuidTypeSerializer : SimpleTypeSerializerStrategy<PackedGuid>
	{
		/// <inheritdoc />
		public override SerializationContextRequirement ContextRequirement { get; } = SerializationContextRequirement.Contextless;

		//See Also: https://github.com/TrinityCore/WowPacketParser/blob/5663c555cb560769df23685bf769c08af277f419/WowPacketParser/Misc/PacketReads.cs#L54
		/// <inheritdoc />
		public override PackedGuid Read(IWireStreamReaderStrategy source)
		{
			//See: https://github.com/jackpoz/BotFarm/blob/592dbc9dbb58c06175bffecfced56eba42107c9a/Client/World/Network/InPacket.cs#L24
			var mask = source.ReadByte();

			if(mask == 0)
				return PackedGuid.Empty;

			ulong res = 0;

			int i = 0;
			while(i < 8)
			{
				if((mask & 1 << i) != 0)
					res += ((ulong)source.ReadByte()) << (i * 8);

				i++;
			}

			return new PackedGuid(res);
		}

		//From jackpoz's bot: https://github.com/jackpoz/BotFarm/blob/592dbc9dbb58c06175bffecfced56eba42107c9a/Client/World/Network/OutPacket.cs#L47
		/// <inheritdoc />
		public override void Write(PackedGuid value, IWireStreamWriterStrategy dest)
		{
			//TODO: Can we use span or stackalloc? Or maybe shared buffer?
			byte[] packGuid = GeneratePackedGuid(value, out int size);

			dest.Write(packGuid, 0, size);
		}

		private static byte[] GeneratePackedGuid(PackedGuid value, out int size)
		{
			byte[] packGuid = new byte[8 + 1];

			size = 1;
			ulong guid = value.RawGuidValue;

			for(byte i = 0; guid != 0; ++i)
			{
				if((guid & 0xFF) != 0)
				{
					packGuid[0] |= (byte)(1 << i);
					packGuid[size] = (byte)(guid & 0xFF);
					++size;
				}

				guid >>= 8;
			}

			return packGuid;
		}

		/// <inheritdoc />
		public override async Task WriteAsync(PackedGuid value, IWireStreamWriterStrategyAsync dest)
		{
			//TODO: Can we use span or stackalloc? Or maybe shared buffer?
			byte[] packGuid = GeneratePackedGuid(value, out int size);

			await dest.WriteAsync(packGuid, 0, size);
		}

		/// <inheritdoc />
		public override async Task<PackedGuid> ReadAsync(IWireStreamReaderStrategyAsync source)
		{
			//See: https://github.com/jackpoz/BotFarm/blob/592dbc9dbb58c06175bffecfced56eba42107c9a/Client/World/Network/InPacket.cs#L24
			var mask = await source.ReadByteAsync();

			if(mask == 0)
				return PackedGuid.Empty;

			ulong res = 0;

			var i = 0;
			while(i < 8)
			{
				if((mask & 1 << i) != 0)
					res += (ulong)(await source.ReadByteAsync()) << (i * 8);

				i++;
			}

			return new PackedGuid(res);
		}
	}
}
