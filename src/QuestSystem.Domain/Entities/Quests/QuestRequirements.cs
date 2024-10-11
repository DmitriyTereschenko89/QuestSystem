namespace QuestSystem.Domain.Entities.Quests
{
    public class QuestRequirements(Guid id, int minimumLevel, HashSet<Guid> previousQuestsCompleted)
    {
        public Guid Id { get; init; } = id;
        public int MinimumLevel { get; init; } = minimumLevel;
        public HashSet<Guid> PreviousQuestsCompleted { get; init; } = previousQuestsCompleted;
    }
}
