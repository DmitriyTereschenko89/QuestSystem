using QuestSystem.Domain.Entities.Quests.Rewards;

namespace QuestSystem.Domain.Entities.Quests.Common
{
    public class Quest
    {
        public Quest() { }
        public Quest(Guid id, Guid conditionId, Guid rewardId, Guid reqiurementId, string name, string description)
        {
            Id = id;
            ConditionId = conditionId;
            RewardId = rewardId;
            Description = description;
            RequirementId = reqiurementId;
            Name = name;
        }

        public Guid Id { get; private set; }
        public Guid ConditionId { get; private set; }
        public Guid RewardId { get; private set; }
        public Guid RequirementId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual Conditions.Conditions QuestCondition { get; set; }
        public virtual Reward QuestReward { get; set; }
        public virtual Requirements.Requirements QuestRequirements { get; set; }

        public void UpdateCondition()
        {
            QuestCondition.UpdateCondition();
        }
    }
}
