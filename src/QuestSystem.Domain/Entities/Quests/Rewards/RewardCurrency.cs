namespace QuestSystem.Domain.Entities.Quests.Rewards
{
    public class RewardCurrency : Reward
    {
        public RewardCurrency()
        { }

        public RewardCurrency(Guid id, int currencyCount) : base(id)
        {
            CurrencyCount = currencyCount;
        }
        public int CurrencyCount { get; init; }
    }
}
