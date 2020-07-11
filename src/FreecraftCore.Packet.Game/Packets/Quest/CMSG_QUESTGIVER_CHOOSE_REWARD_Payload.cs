using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace FreecraftCore
{
	/// <summary>
	/// Packet payload structure for the <see cref="NetworkOperationCode"/> CMSG_QUESTGIVER_CHOOSE_REWARD.
	/// </summary>
	[WireDataContract]
	[GamePayloadOperationCode(NetworkOperationCode.CMSG_QUESTGIVER_CHOOSE_REWARD)]
	public sealed class CMSG_QUESTGIVER_CHOOSE_REWARD_Payload : GamePacketPayload
	{
		[WireMember(1)]
		public ObjectGuid QuestGiver { get; internal set; }

		[WireMember(2)]
		public int QuestId { get; internal set; }

		[WireMember(3)]
		public int RewardSlot { get; internal set; }

		public CMSG_QUESTGIVER_CHOOSE_REWARD_Payload([NotNull] ObjectGuid questGiver, int questId, int rewardSlot)
		{
			if (questId <= 0) throw new ArgumentOutOfRangeException(nameof(questId));
			if (rewardSlot < 0) throw new ArgumentOutOfRangeException(nameof(rewardSlot));

			QuestGiver = questGiver ?? throw new ArgumentNullException(nameof(questGiver));
			QuestId = questId;
			RewardSlot = rewardSlot;
		}

		/// <summary>
		/// Default Serializer Ctor.
		/// </summary>
		internal CMSG_QUESTGIVER_CHOOSE_REWARD_Payload()
		{

		}
	}
}
