namespace QuestSystem.Domain.Entities.Quests.Rewards
{
    public class RewardItem : Reward
    {
        public RewardItem()
        { }

        public RewardItem(Guid id, string itemName) : base(id)
        {
            ItemName = itemName;
        }

        public string ItemName { get; init; }
    }
}
