using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FreecraftCore.Serializer;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	[Owned]
	[WireDataContract]
	public sealed class AchievementCriteriaConditionDefinition
	{
		[WireMember(6)]
		public AchievementCriteriaCondition Condition { get; private set; }

		[WireMember(7)]
		public int AssetId { get; private set; }

		public AchievementCriteriaConditionDefinition(AchievementCriteriaCondition condition, int assetId)
		{
			if (!Enum.IsDefined(typeof(AchievementCriteriaCondition), condition)) throw new InvalidEnumArgumentException(nameof(condition), (int) condition, typeof(AchievementCriteriaCondition));
			Condition = condition;
			AssetId = assetId;
		}

		protected AchievementCriteriaConditionDefinition()
		{

		}
	}
}
