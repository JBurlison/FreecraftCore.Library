using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//CinematicCamera.dbc
	/// <summary>
	/// Table model for CinematicCamera.dbc
	/// https://wowdev.wiki/DB/CinematicCamera
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(CinematicCameraEntry<>))]
	[Table("CinematicCamera")]
	public class CinematicCameraEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		[NotMapped]
		[JsonIgnore]
		public uint EntryId => (uint) CinematicCameraId;

		[Key]
		[WireMember(1)]
		public int CinematicCameraId { get; private set; }

		/// <summary>
		/// Path to camera MDX file.
		/// </summary>
		[WireMember(2)]
		public TStringType Model { get; private set; }

		/// <summary>
		/// Nullable.
		/// <see cref="SoundEntriesEntry{TStringType}"/>.
		/// </summary>
		[WireMember(3)]
		public int VoiceoverSoundId { get; private set; }

		/// <summary>
		/// The coordinates define the end-point, not the start.
		/// </summary>
		[WireMember(4)]
		public Vector3<float> Endpoint { get; private set; }

		/// <summary>
		/// Y-axis end-point orientation.
		/// </summary>
		[WireMember(5)]
		public float Orientation { get; private set; }

		public CinematicCameraEntry(int cinematicCameraId, [NotNull] TStringType model, int voiceoverSoundId, [NotNull] Vector3<float> endpoint, float orientation)
		{
			CinematicCameraId = cinematicCameraId;
			Model = model ?? throw new ArgumentNullException(nameof(model));
			VoiceoverSoundId = voiceoverSoundId;
			Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
			Orientation = orientation;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public CinematicCameraEntry()
		{
			
		}
	}
}
