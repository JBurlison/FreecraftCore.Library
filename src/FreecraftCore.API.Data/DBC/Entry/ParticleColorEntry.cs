using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Numerics;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace FreecraftCore
{
	//TODO: Extension methods
	//ParticleColor.dbc
	/// <summary>
	/// Table model for ParticleColor.dbc
	/// https://wowdev.wiki/DB/ParticleColor
	///
	/// This table defines replacement colors for particles on creature and item models when specific appearances / textures are in use.
	/// For example, the model firefly.m2 has a default green glow on its abdomen, but values given in this table change the value to red (for Blacksting), blue, yellow etc. depending on which colour / textures the firefly is using.
	/// Particle colours are only replaced if the model is using an appearance defined in CreatureDisplayInfo.dbc or ItemDisplayInfo.dbc, and the ParticleColorID from those tables matches an ID value in a row of this database.
	/// Furthermore, the colour is only replaced on particles which have their ParticleColorIndex set to 11, 12 or 13. See M2#Particle_emitters. A ParticleColorIndex of 11, 12 or 13 indicates whether the first, second or third Start, Mid and End colours in this table will be used by the particle.
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[Table("ParticleColor")]
	public class ParticleColorEntry : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => ParticleColorId;

		/// <summary>
		/// Corresponds to ParticleColorID in CreatureDisplayInfo.dbc or ItemDisplayInfo.dbc.
		/// See: <see cref="ItemDisplayInfoEntry{TStringType}"/>
		/// </summary>
		[Key]
		[WireMember(1)]
		public int ParticleColorId { get; internal set; }

		/// <summary>
		/// 0, 1 or 2 used by particle depending on whether it has a ParticleColorIndex of 11, 12 or 13.
		/// The colours are given as 0xAARRGGBB encoded unsigned integers.
		/// </summary>
		[WireMember(2)]
		public GenericStaticallySizedArrayChunkThree<int> StartColor { get; internal set; }

		/// <summary>
		/// 0, 1 or 2 used by particle depending on whether it has a ParticleColorIndex of 11, 12 or 13.
		/// The colours are given as 0xAARRGGBB encoded unsigned integers.
		/// </summary>
		[WireMember(3)]
		public GenericStaticallySizedArrayChunkThree<int> MidColor { get; internal set; }

		/// <summary>
		/// 0, 1 or 2 used by particle depending on whether it has a ParticleColorIndex of 11, 12 or 13.
		/// The colours are given as 0xAARRGGBB encoded unsigned integers.
		/// </summary>
		[WireMember(4)]
		public GenericStaticallySizedArrayChunkThree<int> EndColor { get; internal set; }

		public ParticleColorEntry(int particleColorId, [NotNull] GenericStaticallySizedArrayChunkThree<int> startColor, [NotNull] GenericStaticallySizedArrayChunkThree<int> midColor, [NotNull] GenericStaticallySizedArrayChunkThree<int> endColor)
		{
			if (particleColorId <= 0) throw new ArgumentOutOfRangeException(nameof(particleColorId));

			ParticleColorId = particleColorId;
			StartColor = startColor ?? throw new ArgumentNullException(nameof(startColor));
			MidColor = midColor ?? throw new ArgumentNullException(nameof(midColor));
			EndColor = endColor ?? throw new ArgumentNullException(nameof(endColor));
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public ParticleColorEntry()
		{
			
		}
	}
}
