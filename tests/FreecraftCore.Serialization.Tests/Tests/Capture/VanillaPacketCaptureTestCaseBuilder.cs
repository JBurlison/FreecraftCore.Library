using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;

namespace FreecraftCore
{
	public sealed class VanillaPacketCaptureTestCaseBuilder : PacketCaptureTestCaseCaptureBuilder
	{
		/// <inheritdoc />
		public override ExpansionType Expac { get; } = ExpansionType.Vanilla;

		public VanillaPacketCaptureTestCaseBuilder()
		{
			
		}

		/// <inheritdoc />
		public override IEnumerable<Type> BuildSerializableTypes()
		{
			//Then we want to register DTOs for unknown
			return GamePacketStubMetadataMarker.GamePacketPayloadStubTypes
				.Where(t => VanillaGamePacketMetadataMarker.UnimplementedOperationCodes.Value.Contains(AttributesUtil.GetAttribute<GamePayloadOperationCodeAttribute>((Type)t).OperationCode))
				.Concat(VanillaGamePacketMetadataMarker.SerializableTypes)
				.ToArray();
		}
	}
}