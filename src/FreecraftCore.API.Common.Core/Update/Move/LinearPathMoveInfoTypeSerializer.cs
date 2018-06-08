using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using Reinterpret.Net;

namespace FreecraftCore
{
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

			//TODO: Deserialize to vectors
			//Then there are a bunch of packed points here
			byte[] packedDataBytes = lastIndex > 1 ? source.ReadBytes((lastIndex - 1) * sizeof(int)) : Array.Empty<byte>();

			return new LinearPathMoveInfo(lastIndex, lastPoint, packedDataBytes);
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
				dest.Write(value.SplineMiddlePoints);
		}

		/// <inheritdoc />
		public override async Task WriteAsync(LinearPathMoveInfo value, IWireStreamWriterStrategyAsync dest)
		{
			await dest.WriteAsync(value.LastIndex.Reinterpret());

			await dest.WriteAsync(value.FinalPosition.X.Reinterpret());
			await dest.WriteAsync(value.FinalPosition.Y.Reinterpret());
			await dest.WriteAsync(value.FinalPosition.Z.Reinterpret());

			await dest.WriteAsync(value.SplineMiddlePoints);
		}

		/// <inheritdoc />
		public override Task<LinearPathMoveInfo> ReadAsync(IWireStreamReaderStrategyAsync source)
		{
			throw new NotImplementedException("TODO: Implement async LinearPathMoveInfo");
		}
	}
}
