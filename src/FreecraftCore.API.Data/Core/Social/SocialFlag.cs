using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public enum SocialFlag
	{
		FRIEND = 0x01,

		IGNORED = 0x02,

		/// <summary>
		/// Guessed
		/// </summary>
		MUTED = 0x04,

		/// <summary>
		///  Unknown - does not appear to be RaF
		/// </summary>
		UNK = 0x08,

		SOCIAL_FLAG_ALL = FRIEND | IGNORED | MUTED
	};
}
