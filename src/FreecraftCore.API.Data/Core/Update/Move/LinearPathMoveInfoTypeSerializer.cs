using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using Reinterpret.Net;

namespace FreecraftCore
{
	internal static class LinearPathReinterpretCastExtensions
	{
		public static unsafe float AsFloat(this uint n) => *(float*)&n;
		public static unsafe uint AsInt(this float n) => *(uint*)&n;
	}

	public sealed class LinearPathMoveInfoTypeSerializer : SimpleTypeSerializerStrategy<LinearPathMoveInfo>
	{
		/// <inheritdoc />
		public override SerializationContextRequirement ContextRequirement { get; } = SerializationContextRequirement.Contextless;

		public LinearPathMoveInfoTypeSerializer()
		{
			
		}

		/// <inheritdoc />
		public override LinearPathMoveInfo Read(IWireStreamReaderStrategy source)
		{
			int lastIndex = source.ReadBytes(4).Reinterpret<int>();

			byte[] lastPointBytes = source.ReadBytes(sizeof(float) * 3);

			Vector3<float> lastPoint = new Vector3<float>(lastPointBytes.Reinterpret<float>(),
				lastPointBytes.Reinterpret<float>(sizeof(float)), lastPointBytes.Reinterpret<float>(sizeof(float) * 2));

			/*// can be used in SMSG_MONSTER_MOVE opcode
			void appendPackXYZ(float x, float y, float z)
			{
				uint32 packed = 0;
				packed |= ((int)(x / 0.25f) & 0x7FF);
				packed |= ((int)(y / 0.25f) & 0x7FF) << 11;
				packed |= ((int)(z / 0.25f) & 0x3FF) << 22;
				*this << packed;
			}*/

			/*G3D::Vector3 middle = (real_path[0] + real_path[last_idx]) / 2.f;
			G3D::Vector3 offset;
			// first and last points already appended
			for (uint32 i = 1; i < last_idx; ++i)
			{
				offset = middle - real_path[i];
				data << TaggedPosition<Position::PackedXYZ>(offset.x, offset.y, offset.z);
			}*/
			Vector3<float>[] middlePoints = new Vector3<float>[lastIndex - 1];
			if (lastIndex > 1)
			{
				for (int i = 1; i < lastIndex; ++i)
				{
					uint packedFloats = source.ReadBytes(sizeof(uint)).Reinterpret<uint>();
					float x = (packedFloats & 0x7FF).AsFloat() * 0.25f;
					float y = ((packedFloats >> 11) & 0x7FF).AsFloat() * 0.25f;
					float z = ((packedFloats >> 22) & 0x3FF).AsFloat() * 0.25f;
					middlePoints[i - 1] = new Vector3<float>(x, y, z);
				}
			}

			return new LinearPathMoveInfo(lastIndex, lastPoint, middlePoints);
		}


		/// <inheritdoc />
		public override void Write(LinearPathMoveInfo value, IWireStreamWriterStrategy dest)
		{
			if(value == null)
				return;

			dest.Write(value.LastIndex.Reinterpret());

			dest.Write(value.FinalPosition.X.Reinterpret());
			dest.Write(value.FinalPosition.Y.Reinterpret());
			dest.Write(value.FinalPosition.Z.Reinterpret());

			if(value.LastIndex > 1 && value.SplineMiddlePoints != null)
				throw new NotImplementedException($"TODO: Implement mid points.");
		}

		/// <inheritdoc />
		public override async Task WriteAsync(LinearPathMoveInfo value, IWireStreamWriterStrategyAsync dest)
		{
			await dest.WriteAsync(value.LastIndex.Reinterpret());

			await dest.WriteAsync(value.FinalPosition.X.Reinterpret());
			await dest.WriteAsync(value.FinalPosition.Y.Reinterpret());
			await dest.WriteAsync(value.FinalPosition.Z.Reinterpret());

			throw new NotImplementedException($"TODO: Implement mid points.");
		}

		/// <inheritdoc />
		public override Task<LinearPathMoveInfo> ReadAsync(IWireStreamReaderStrategyAsync source)
		{
			throw new NotImplementedException("TODO: Implement async LinearPathMoveInfo");
		}
	}
}
