using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class GameObjectQueryResponseInfo
	{
		//TODO: Get enum for this
		[WireMember(1)]
		public int GameObjectType { get; }

		[WireMember(2)]
		public int DisplayId { get; }

		[Encoding(EncodingType.ASCII)]
		[KnownSize(4)]
		[WireMember(3)]
		public string[] Names { get; }

		[Encoding(EncodingType.ASCII)]
		[WireMember(4)]
		public string IconName { get; }

		[Encoding(EncodingType.ASCII)]
		[WireMember(5)]
		public string CastBarCaption { get; }

		[Encoding(EncodingType.ASCII)]
		[WireMember(6)]
		public string UnkString { get; }

		[WireMember(7)]
		[KnownSize(sizeof(int) * 24)]
		public byte[] Data { get; }

		[WireMember(8)]
		public float Size { get; }

		[KnownSize(6)]
		[WireMember(9)]
		public int[] QuestItemIds { get; }

		/// <inheritdoc />
		public GameObjectQueryResponseInfo(int gameObjectType, int displayId, string[] names, string iconName, string castBarCaption, string unkString, byte[] data, float size, int[] questItemIds)
		{
			GameObjectType = gameObjectType;
			DisplayId = displayId;
			Names = names;
			IconName = iconName;
			CastBarCaption = castBarCaption;
			UnkString = unkString;
			Data = data;
			Size = size;
			QuestItemIds = questItemIds;
		}

		protected GameObjectQueryResponseInfo()
		{
			
		}
	}
}
