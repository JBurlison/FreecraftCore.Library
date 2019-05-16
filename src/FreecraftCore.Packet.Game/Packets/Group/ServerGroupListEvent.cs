using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.SMSG_GROUP_LIST)]
	public sealed class ServerGroupListEvent : GamePacketPayload
	{
		[WireMember(1)]
		public GroupType PartyType { get; private set; }

		//TODO: Consolidate since other things use this pattern
		[WireMember(2)]
		public byte LocalPlayerGroupId { get; private set; }

		[WireMember(3)]
		public GroupMemberFlags LocalPlayerGroupMemberFlags { get; private set; }

		[WireMember(4)]
		public LfgRoles OptionalDungeonLFGRoles { get; private set; }

		//TODO: This packet does NOT handle LFG, there can be 5 bytes here if the PartyType indicates it's LFG.

		[WireMember(7)]
		public ObjectGuid GroupGuid { get; private set; } //EntityGuidMask.Group

		//TrinityCore increments this every time, for some reason. Useless to us.
		[WireMember(8)]
		public int UpdateCounter { get; private set; }

		//Follow is a collection of group member data. Similar to above.
		[SendSize(SendSizeAttribute.SizeType.Int32)] //for some reason Blizzard wasted 3 bytes here.
		[WireMember(9)]
		private GroupListMemberData[] _GroupMemberDataList { get; set; }

		/// <summary>
		/// List of group member data contains all member data EXCEPT the local player.
		/// </summary>
		private IReadOnlyCollection<GroupListMemberData> GroupMemberDataList => _GroupMemberDataList;

		[WireMember(10)]
		public ObjectGuid LeaderGuid { get; private set; }

		public bool isGroupHaveAnyMembers => _GroupMemberDataList != null && _GroupMemberDataList.Any();

		//This is only sent if the group actually has members in it
		/// <summary>
		/// USUALLY set, check <see cref="isGroupHaveAnyMembers"/> first as this
		/// can be null otherwise. Not sent in a party of 1.
		/// </summary>
		[Optional(nameof(isGroupHaveAnyMembers))]
		[WireMember(11)]
		public GroupSettingsData OptionalGroupSettings { get; private set; }

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public ServerGroupListEvent()
		{
			
		}
	}
}
