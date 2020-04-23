using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//CameraShakes.dbc
	/// <summary>
	/// Table model for CameraShakes.dbc
	/// https://wowdev.wiki/DB/CameraShakes
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[Table("CameraShakes")]
	public class CameraShakesEntry : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public uint EntryId => (uint)CameraShakeId;

		[Key]
		[WireMember(1)]
		public int CameraShakeId { get; private set; }

		[WireMember(2)]
		public CGCameraShakeType ShakeType { get; private set; }

		[WireMember(3)]
		public CGCameraDir Direction { get; private set; }

		/// <summary>
		/// Multiplied by 0.027777778f when passed to CGCamera::AddShake.
		/// </summary>
		[WireMember(4)]
		public float Amplitude { get; private set; }

		[WireMember(5)]
		public float Frequency { get; private set; }

		[WireMember(6)]
		public float Duration { get; private set; }

		[WireMember(7)]
		public float Phase { get; private set; }

		[WireMember(8)]
		public float Coefficient { get; private set; }

		public CameraShakesEntry(int cameraShakeId, CGCameraShakeType shakeType, CGCameraDir direction, float amplitude, float frequency, float duration, float phase, float coefficient)
		{
			if (!Enum.IsDefined(typeof(CGCameraShakeType), shakeType)) throw new InvalidEnumArgumentException(nameof(shakeType), (int) shakeType, typeof(CGCameraShakeType));
			if (!Enum.IsDefined(typeof(CGCameraDir), direction)) throw new InvalidEnumArgumentException(nameof(direction), (int) direction, typeof(CGCameraDir));
			if (cameraShakeId <= 0) throw new ArgumentOutOfRangeException(nameof(cameraShakeId));

			CameraShakeId = cameraShakeId;
			ShakeType = shakeType;
			Direction = direction;
			Amplitude = amplitude;
			Frequency = frequency;
			Duration = duration;
			Phase = phase;
			Coefficient = coefficient;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public CameraShakesEntry()
		{
			
		}
	}
}
