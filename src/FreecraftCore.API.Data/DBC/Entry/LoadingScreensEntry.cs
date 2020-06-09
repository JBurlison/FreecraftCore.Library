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
	//LoadingScreens.dbc
	/// <summary>
	/// Table model for LoadingScreens.dbc
	/// https://wowdev.wiki/DB/LoadingScreens
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(LoadingScreensEntry<>))]
	[Table("LoadingScreens")]
	public class LoadingScreensEntry<TStringType> : IDBCEntryIdentifiable
		where TStringType : class
	{
		public static readonly string[] INTERNAL_FIELD_NAMES = new string[1] { nameof(HasWideScreen) };

		[NotMapped]
		[JsonIgnore]
		public int EntryId => LoadingScreenId;

		[Key]
		[WireMember(1)]
		public int LoadingScreenId { get; internal set; }

		[WireMember(2)]
		public TStringType Name { get; internal set; }

		[WireMember(3)]
		public TStringType FilePath { get; internal set; }

		[WireMember(4)]
		internal int HasWideScreen { get; set; }

		[JsonIgnore]
		[NotMapped]
		public bool HasWideScreenVersion => HasWideScreen != 0;

		public LoadingScreensEntry(int loadingScreenId, [NotNull] TStringType name, [NotNull] TStringType filePath, int hasWideScreen)
		{
			LoadingScreenId = loadingScreenId;
			Name = name ?? throw new ArgumentNullException(nameof(name));
			FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
			HasWideScreen = hasWideScreen;
		}


		//DBC Tools requires this to be public.
		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public LoadingScreensEntry()
		{

		}
	}
}
