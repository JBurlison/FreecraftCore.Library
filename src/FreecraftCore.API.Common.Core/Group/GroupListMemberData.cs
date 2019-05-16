using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	public sealed class GroupListMemberData
	{
		[WireMember(1)]
		public string PlayerName { get; private set; }

		[WireMember(2)]
		public ObjectGuid PlayerGuid { get; private set; }

		[WireMember(3)]
		public GroupMemberOnlineStatus MemberStatus { get; private set; }

		[WireMember(4)]
		public byte GroupId { get; private set; }

		[WireMember(5)]
		public GroupMemberFlags MemberFlags { get; private set; }

		[WireMember(6)]
		public LfgRoles OptionalDungeonLFGRoles { get; private set; }

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		private GroupListMemberData()
		{
			
		}
	}
}
