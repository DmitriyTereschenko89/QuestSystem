namespace QuestSystem.Domain.Entities.Quests
{
    public class Quest(Guid id, string name, string description, QuestConditions questCondition, QuestReward questReward, QuestRequirements questRequirements)
    {
        public Guid Id { get; init; } = id;
        public string Name { get; init; } = name;
        public string Description { get; init; } = description;
        public QuestConditions QuestCondition { get; init; } = questCondition;
        public QuestReward QuestReward { get; init; } = questReward;
        public QuestRequirements QuestRequirements { get; init; } = questRequirements;

        public void UpdateCondition()
        {
            QuestCondition.UpdateCondition();
        }
    }
}
