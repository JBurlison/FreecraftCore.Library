using System;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	[WireDataContract]
	public class TransportationInfo_Vanilla
	{
		//ClientVersion.AddedInVersion(ClientVersionBuild.V3_1_0_9767) post 3.1 it was a packedguid instead of a guid.
		/// <summary>
		/// The GUID of the transport.
		/// (Unpacked)
		/// </summary>
		[WireMember(1)]
		public ObjectGuid TransportGuid { get; }

		//TODO: What is this?
		[WireMember(2)]
		public Vector4<float> TransportOffset { get; }
		
		//1.12.1 only sends guid and offset

		/// <inheritdoc />
		public TransportationInfo_Vanilla(ObjectGuid transportGuid, Vector4<float> transportOffset)
		{
			TransportGuid = transportGuid;
			TransportOffset = transportOffset;
		}

		protected TransportationInfo_Vanilla()
		{

		}
	}
}