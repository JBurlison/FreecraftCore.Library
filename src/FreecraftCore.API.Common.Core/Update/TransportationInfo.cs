using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public class TransportationInfo
	{
		//ClientVersion.AddedInVersion(ClientVersionBuild.V3_1_0_9767) post 3.1 it was a packedguid instead of a guid.
		/// <summary>
		/// The GUID of the transport.
		/// </summary>
		[WireMember(1)]
		public PackedGuid TransportGuid { get; }

		//TODO: What is this?
		[WireMember(2)]
		public Vector4<float> TransportOffset { get; }

		//ClientVersion.AddedInVersion(ClientType.WrathOfTheLichKing)
		/// <summary>
		/// Indicates the id of the transportation seat.
		/// </summary>
		[WireMember(3)]
		public byte TransportSeatId { get; }

		/// <inheritdoc />
		public TransportationInfo([NotNull] PackedGuid transportGuid, [NotNull] Vector4<float> transportOffset, byte transportSeatId)
		{
			TransportGuid = transportGuid ?? throw new ArgumentNullException(nameof(transportGuid));
			TransportOffset = transportOffset ?? throw new ArgumentNullException(nameof(transportOffset));
			TransportSeatId = transportSeatId;
		}

		protected TransportationInfo()
		{
			
		}
	}
}