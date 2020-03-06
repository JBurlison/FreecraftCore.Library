using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	public sealed class SpellMissInfo
	{
		[WireMember(1)]
		public ObjectGuid Target { get; }

		[WireMember(2)]
		public SpellMissReasonType MissReason { get; }

		public bool HasReflectResult => MissReason == SpellMissReasonType.SPELL_MISS_REFLECT;

		[Optional(nameof(HasReflectResult))]
		[WireMember(3)]
		public SpellMissReasonType ReflectMissReason { get; }

		//TODO: Validate parameters
		public SpellMissInfo([NotNull] ObjectGuid target, SpellMissReasonType missReason, SpellMissReasonType reflectMissReason)
		{
			Target = target ?? throw new ArgumentNullException(nameof(target));
			MissReason = missReason;
			ReflectMissReason = reflectMissReason;
		}

		public SpellMissInfo([NotNull] ObjectGuid target, SpellMissReasonType missReason)
		{
			Target = target ?? throw new ArgumentNullException(nameof(target));
			MissReason = missReason;
		}

		protected SpellMissInfo()
		{
			
		}
	}
}
