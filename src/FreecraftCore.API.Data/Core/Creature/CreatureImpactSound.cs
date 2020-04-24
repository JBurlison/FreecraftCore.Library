using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public static class CreatureImpactSoundExtensions
	{
		/// <summary>
		/// s_creatureIpactSounds
		/// </summary>
		public static readonly CreatureImpactSound[] CreatureImpactSoundArray = new CreatureImpactSound[]{ CreatureImpactSound.FLESH, CreatureImpactSound.STONE, CreatureImpactSound.WOOD, CreatureImpactSound.ETHEREAL };
	}

	//See: https://wowdev.wiki/DB/CreatureSoundData
	/// <summary>
	/// used by ? CGUnit_C::GetImpactType
	/// </summary>
	public enum CreatureImpactSound
	{
		FLESH = 0, 
		STONE = 8, 
		WOOD = 7, 
		ETHEREAL = 9
	};
}
