namespace QuestSystem.Domain.Entities.Quests
{
    public class Currency(Guid id, int currencyCount) : QuestReward(id)
    {
        public int CurrencyCount { get; init; } = currencyCount;
    }
}
