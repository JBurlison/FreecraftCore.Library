using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	[Flags]
	public enum GroupMemberFlags : byte
	{
		MEMBER_FLAG_ASSISTANT = 0x01,
		MEMBER_FLAG_MAINTANK = 0x02,
		MEMBER_FLAG_MAINASSIST = 0x04
	}
}
