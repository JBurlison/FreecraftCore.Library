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
	//NPCSounds.dbc
	/// <summary>
	/// Table model for NPCSounds.dbc
	/// https://wowdev.wiki/DB/NPCSounds
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[Table("NPCSounds")]
	public class NPCSoundsEntry : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => NpcSoundId;

		[Key]
		[WireMember(1)]
		public int NpcSoundId { get; private set; }

		[WireMember(2)]
		public int GreetingsSoundId { get; private set; }

		/// <summary>
		/// All NPCSounds definitions contain a valid non-null
		/// reference to <see cref="SoundEntriesEntry{TStringType}"/> for their greetings sound.
		/// </summary>
		[ForeignKey(nameof(GreetingsSoundId))]
		[JsonIgnore]
		public virtual SoundEntriesEntry<string> GreetingsSound { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: <see cref="SoundEntriesEntry{TStringType}"/>
		/// </summary>
		[WireMember(3)]
		public int GoodbyeSoundId { get; private set; }

		/// <summary>
		/// Nullable.
		/// See: <see cref="SoundEntriesEntry{TStringType}"/>
		/// </summary>
		[WireMember(4)]
		public int AnnoyedSoundId { get; private set; }

		/// <summary>
		/// Unknown/TODO.
		/// Q: stores last sound file? memory allocation when table is loaded.
		/// </summary>
		[WireMember(5)]
		public int UnknownSoundId { get; private set; }

		public NPCSoundsEntry(int npcSoundId, int greetingsSoundId, int goodbyeSoundId, int annoyedSoundId, int unknownSoundId)
		{
			if (npcSoundId <= 0) throw new ArgumentOutOfRangeException(nameof(npcSoundId));
			if (greetingsSoundId <= 0) throw new ArgumentOutOfRangeException(nameof(greetingsSoundId));

			NpcSoundId = npcSoundId;
			GreetingsSoundId = greetingsSoundId;
			GoodbyeSoundId = goodbyeSoundId;
			AnnoyedSoundId = annoyedSoundId;
			UnknownSoundId = unknownSoundId;
		}

		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public NPCSoundsEntry()
		{
			
		}
	}

	public static class NPCSoundsEntryExtensions
	{
		/// <summary>
		/// Indicates if <see cref="NPCSoundsEntry"/> <see cref="entry"/> contains the requested <see cref="soundType"/>.
		/// </summary>
		/// <param name="entry">Entry to check.</param>
		/// <param name="soundType">Sound type.</param>
		/// <returns></returns>
		public static bool HasSoundType([NotNull] this NPCSoundsEntry entry, NpcSounds soundType)
		{
			if (entry == null) throw new ArgumentNullException(nameof(entry));
			if (!Enum.IsDefined(typeof(NpcSounds), soundType)) throw new InvalidEnumArgumentException(nameof(soundType), (int) soundType, typeof(NpcSounds));

			switch (soundType)
			{
				case NpcSounds.HELLO:
					return entry.GreetingsSoundId > 0;
				case NpcSounds.GOODBYE:
					return entry.GoodbyeSoundId > 0;
				case NpcSounds.PISSED:
					return entry.AnnoyedSoundId > 0;
				case NpcSounds.ACK:
					return false; //TODO: Unused
				default:
					throw new ArgumentOutOfRangeException(nameof(soundType), soundType, null);
			}
		}

		/// <summary>
		/// Retrieves the <see cref="SoundEntriesEntry{TStringType}"/> id from the <see cref="entry"/> for
		/// the <see cref="soundType"/>.
		/// </summary>
		/// <param name="entry">The entry.</param>
		/// <param name="soundType">The sound type.</param>
		/// <returns></returns>
		public static int GetSoundEntryId([NotNull] this NPCSoundsEntry entry, NpcSounds soundType)
		{
			if (!HasSoundType(entry, soundType))
				throw new InvalidOperationException($"{nameof(NPCSoundsEntry)} does not contain SoundType: {soundType}. Check {nameof(HasSoundType)} first.");

			switch (soundType)
			{
				case NpcSounds.HELLO:
					return entry.GreetingsSoundId;
				case NpcSounds.GOODBYE:
					return entry.GoodbyeSoundId;
				case NpcSounds.PISSED:
					return entry.AnnoyedSoundId;
				case NpcSounds.ACK:
					return entry.UnknownSoundId;
				default:
					throw new ArgumentOutOfRangeException(nameof(soundType), soundType, null);
			}
		}
	}
}
