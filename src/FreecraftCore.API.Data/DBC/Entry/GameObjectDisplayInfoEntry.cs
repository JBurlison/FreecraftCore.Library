using System;
using System.Collections.Generic;
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
	//GameObjectDisplayInfo.dbc
	/// <summary>
	/// Table model for GameObjectDisplayInfo.dbc
	/// https://wowdev.wiki/DB/GameObjectDisplayInfo
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(GameObjectDisplayInfoEntry<>))]
	[Table("GameObjectDisplayInfo")]
	public class GameObjectDisplayInfoEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => GameObjectDisplayInfoId;

		/// <summary>
		/// Primary key.
		/// </summary>
		[Key]
		[WireMember(1)]
		public int GameObjectDisplayInfoId { get; internal set; }

		/// <summary>
		/// The file path to the model.
		/// </summary>
		[WireMember(2)]
		public TStringType ModelPath { get; internal set; }

		[WireMember(3)]
		public GenericStaticallySizedArrayChunkTen<int> SoundSlot { get; internal set; }

		[WireMember(4)]
		public Vector3<float> BoxMin { get; internal set; }

		[WireMember(5)]
		public Vector3<float> BoxMax { get; internal set; }

		/// <summary>
		/// Nullable/Optional
		/// See: <see cref="ObjectEffectPackageEntry{TStringType}"/>.
		/// </summary>
		[WireMember(6)]
		public int ObjectEffectsPackageId { get; internal set; }

		public GameObjectDisplayInfoEntry(int gameObjectDisplayInfoId, 
			[NotNull] TStringType modelPath,
			[NotNull] GenericStaticallySizedArrayChunkTen<int> soundSlot, [NotNull] Vector3<float> boxMin, [NotNull] Vector3<float> boxMax, int objectEffectsPackageId)
		{
			if (gameObjectDisplayInfoId <= 0) throw new ArgumentOutOfRangeException(nameof(gameObjectDisplayInfoId));

			GameObjectDisplayInfoId = gameObjectDisplayInfoId;
			ModelPath = modelPath ?? throw new ArgumentNullException(nameof(modelPath));
			SoundSlot = soundSlot ?? throw new ArgumentNullException(nameof(soundSlot));
			BoxMin = boxMin ?? throw new ArgumentNullException(nameof(boxMin));
			BoxMax = boxMax ?? throw new ArgumentNullException(nameof(boxMax));
			ObjectEffectsPackageId = objectEffectsPackageId;
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public GameObjectDisplayInfoEntry()
		{
			
		}
	}

	public static class GameObjectDisplayInfoExtensions
	{
		public static bool HasSoundEntry<TStringType>([NotNull] this GameObjectDisplayInfoEntry<TStringType> entry, GameObjectSoundSlot slot) 
			where TStringType : class
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));

			return entry.SoundSlot[(int) slot] > 0;
		}

		public static int GetSoundEntry<TStringType>([NotNull] this GameObjectDisplayInfoEntry<TStringType> entry, GameObjectSoundSlot slot)
			where TStringType : class
		{
			if(entry == null) throw new ArgumentNullException(nameof(entry));

			return entry.SoundSlot[(int) slot];
		}
	}
}
