namespace QuestSystem.Domain.Entities.Quests
{
    public class Item(Guid id, string itemName) : QuestReward(id)
    {
        public string ItemName { get; init; } = itemName;
    }
}
