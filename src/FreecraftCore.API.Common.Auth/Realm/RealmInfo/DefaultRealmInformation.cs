using FreecraftCore.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using JetBrains.Annotations;

namespace FreecraftCore.API.Common
{
	//TODO: Refactor parts shared between different queries into seperate objects
	[WireDataContract]
	public class DefaultRealmInformation : IRealmInformation
	{
		//TODO: Should we hide this an expose the information in a more OOP way?
		/// <summary>
		/// Packed information about the realm.
		/// </summary>
		[WireMember(1)]
		public RealmFlags Flags { get; }

		/// <summary>
		/// The string the realm should display on the realmlist tab.
		/// This might not be only the name. It could include build information.
		/// </summary>
		[Encoding(EncodingType.ASCII)]
		[WireMember(2)]
		public string RealmString { get; }

		/// <summary>
		/// Endpoint information for the realm.
		/// </summary>
		[WireMember(3)]
		public RealmEndpoint RealmAddress { get; }

		//Maybe wrap this into something? Query it for realm pop info? I don't know
		//TODO: Research Mangos and Ember to find out why this is a float.
		//Odd that this is a float.
		[WireMember(4)]
		public float PopulationLevel { get; }

		/// <summary>
		/// Indicates how many character's the account of the client has
		/// on this realm.
		/// </summary>
		[WireMember(5)]
		public byte CharacterCount { get; }

		//TODO: Ok, which time zone maps to which byte?
		[WireMember(6)]
		public byte RealmTimeZone { get; }

		//2.x and 3.x clients expect the realm index.
		//1.12.1 just expect a byte-sized 0
		/// <summary>
		/// Indicates the ID of the realm.
		/// </summary>
		[WireMember(7)]
		public byte RealmId { get; }

		/// <inheritdoc />
		public DefaultRealmInformation(RealmFlags flags, [NotNull] string realmString, [NotNull] RealmEndpoint realmAddress, float populationLevel, byte characterCount, byte realmTimeZone, byte realmId)
		{
			if(realmAddress == null) throw new ArgumentNullException(nameof(realmAddress));
			if(!Enum.IsDefined(typeof(RealmFlags), flags)) throw new ArgumentOutOfRangeException(nameof(flags), "Value should be defined in the RealmFlags enum.");
			if(string.IsNullOrWhiteSpace(realmString)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(realmString));

			Flags = flags;
			RealmString = realmString;
			RealmAddress = realmAddress;
			PopulationLevel = populationLevel;
			CharacterCount = characterCount;
			RealmTimeZone = realmTimeZone;
			RealmId = realmId;
		}

		protected DefaultRealmInformation()
		{

		}
	}
}
