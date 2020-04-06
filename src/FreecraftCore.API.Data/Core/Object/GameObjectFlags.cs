using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	//TODO: Doc with comments.
	[Flags]
	public enum GameObjectFlags
	{
		GO_FLAG_IN_USE = 0x00000001,                   // disables interaction while animated
		GO_FLAG_LOCKED = 0x00000002,                   // require key, spell, event, etc to be opened. Makes "Locked" appear in tooltip
		GO_FLAG_INTERACT_COND = 0x00000004,                   // cannot interact (condition to interact - requires GO_DYNFLAG_LO_ACTIVATE to enable interaction clientside)
		GO_FLAG_TRANSPORT = 0x00000008,                   // any kind of transport? Object can transport (elevator, boat, car)
		GO_FLAG_NOT_SELECTABLE = 0x00000010,                   // not selectable even in GM mode
		GO_FLAG_NODESPAWN = 0x00000020,                   // never despawn, typically for doors, they just change state
		GO_FLAG_AI_OBSTACLE = 0x00000040,                   // makes the client register the object in something called AIObstacleMgr, unknown what it does
		GO_FLAG_FREEZE_ANIMATION = 0x00000080,
		GO_FLAG_DAMAGED = 0x00000200,
		GO_FLAG_DESTROYED = 0x00000400
	};
}
