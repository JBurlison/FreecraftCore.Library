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
	//ServerMessages.dbc
	/// <summary>
	/// Table model for ServerMessages.dbc
	/// https://wowdev.wiki/DB/ServerMessages
	/// </summary>
	[DBC]
	[WireDataContract]
	[JsonObject]
	[StringDBC(typeof(ServerMessagesEntry<>))]
	[Table("ServerMessages")]
	public class ServerMessagesEntry<TStringType> : IDBCEntryIdentifiable
	{
		[NotMapped]
		[JsonIgnore]
		public int EntryId => MessageId;

		[Key]
		[WireMember(1)]
		public int MessageId { get; private set; }

		[WireMember(2)]
		public LocalizedStringDBC<TStringType> Text { get; private set; }

		public ServerMessagesEntry(int messageId, [NotNull] LocalizedStringDBC<TStringType> text)
		{
			if (messageId <= 0) throw new ArgumentOutOfRangeException(nameof(messageId));

			MessageId = messageId;
			Text = text ?? throw new ArgumentNullException(nameof(text));
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public ServerMessagesEntry()
		{
			
		}
	}
}
