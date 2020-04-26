using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public enum NpcSounds
	{
		/// <summary>
		/// Greetings 
		/// </summary>
		HELLO = 0,

		/// <summary>
		/// Farewells
		/// </summary>
		GOODBYE = 1,

		/// <summary>
		/// Annoyed.
		/// </summary>
		PISSED = 2,

		/// <summary>
		/// Unknown/TODO.
		/// Wiki says: Q: stores last sound file? memory allocation when table is loaded.
		/// </summary>
		ACK = 3,

		//NUM_NPCSOUNDS = 4
	};
}
