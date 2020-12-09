using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FreecraftCore.Serializer;
using FreecraftCore;

namespace FreecraftCore.Serializer
{
    //THIS CODE IS FOR AUTO-GENERATED SERIALIZERS! DO NOT MODIFY UNLESS YOU KNOW WELL!
    /// <summary>
    /// FreecraftCore.Serializer's AUTO-GENERATED (do not edit) serialization
    /// code for the Type: <see cref="GroupListMemberData"/>
    /// </summary>
    public sealed partial class GroupListMemberData_AutoGeneratedTemplateSerializerStrategy
        : BaseAutoGeneratedSerializerStrategy<GroupListMemberData_AutoGeneratedTemplateSerializerStrategy, GroupListMemberData>
    {
        /// <summary>
        /// Auto-generated deserialization/read method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalRead(GroupListMemberData value, Span<byte> buffer, ref int offset)
        {
            //Type: GroupListMemberData Field: 1 Name: PlayerName Type: String;
            value.PlayerName = TerminatedStringTypeSerializerStrategy<ASCIIStringTypeSerializerStrategy, ASCIIStringTerminatorTypeSerializerStrategy>.Instance.Read(buffer, ref offset);
            //Type: GroupListMemberData Field: 2 Name: PlayerGuid Type: ObjectGuid;
            value.PlayerGuid = ObjectGuid_AutoGeneratedTemplateSerializerStrategy.Instance.Read(buffer, ref offset);
            //Type: GroupListMemberData Field: 3 Name: MemberStatus Type: GroupMemberOnlineStatus;
            value.MemberStatus = GenericPrimitiveEnumTypeSerializerStrategy<GroupMemberOnlineStatus, Byte>.Instance.Read(buffer, ref offset);
            //Type: GroupListMemberData Field: 4 Name: GroupId Type: Byte;
            value.GroupId = BytePrimitiveSerializerStrategy.Instance.Read(buffer, ref offset);
            //Type: GroupListMemberData Field: 5 Name: MemberFlags Type: GroupMemberFlags;
            value.MemberFlags = GenericPrimitiveEnumTypeSerializerStrategy<GroupMemberFlags, Byte>.Instance.Read(buffer, ref offset);
            //Type: GroupListMemberData Field: 6 Name: OptionalDungeonLFGRoles Type: LfgRoles;
            value.OptionalDungeonLFGRoles = GenericPrimitiveEnumTypeSerializerStrategy<LfgRoles, Byte>.Instance.Read(buffer, ref offset);
        }

        /// <summary>
        /// Auto-generated serialization/write method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalWrite(GroupListMemberData value, Span<byte> buffer, ref int offset)
        {
            //Type: GroupListMemberData Field: 1 Name: PlayerName Type: String;
            TerminatedStringTypeSerializerStrategy<ASCIIStringTypeSerializerStrategy, ASCIIStringTerminatorTypeSerializerStrategy>.Instance.Write(value.PlayerName, buffer, ref offset);
            //Type: GroupListMemberData Field: 2 Name: PlayerGuid Type: ObjectGuid;
            ObjectGuid_AutoGeneratedTemplateSerializerStrategy.Instance.Write(value.PlayerGuid, buffer, ref offset);
            //Type: GroupListMemberData Field: 3 Name: MemberStatus Type: GroupMemberOnlineStatus;
            GenericPrimitiveEnumTypeSerializerStrategy<GroupMemberOnlineStatus, Byte>.Instance.Write(value.MemberStatus, buffer, ref offset);
            //Type: GroupListMemberData Field: 4 Name: GroupId Type: Byte;
            BytePrimitiveSerializerStrategy.Instance.Write(value.GroupId, buffer, ref offset);
            //Type: GroupListMemberData Field: 5 Name: MemberFlags Type: GroupMemberFlags;
            GenericPrimitiveEnumTypeSerializerStrategy<GroupMemberFlags, Byte>.Instance.Write(value.MemberFlags, buffer, ref offset);
            //Type: GroupListMemberData Field: 6 Name: OptionalDungeonLFGRoles Type: LfgRoles;
            GenericPrimitiveEnumTypeSerializerStrategy<LfgRoles, Byte>.Instance.Write(value.OptionalDungeonLFGRoles, buffer, ref offset);
        }
    }
}